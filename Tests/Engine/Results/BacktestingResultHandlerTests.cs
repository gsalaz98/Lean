/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using Deedle;
using NUnit.Framework;
using QuantConnect.Algorithm.CSharp;
using QuantConnect.Report;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantConnect.Tests.Engine.Results
{
    [TestFixture]
    public class BacktestingResultHandlerTests
    {
        [TestCase(nameof(BasicTemplateAlgorithm))]
        [TestCase(nameof(BasicTemplateDailyAlgorithm))]
        [TestCase(nameof(BasicTemplateFrameworkAlgorithm))]
        public void SamplesNotMisaligned(string algorithm)
        {
            var parameter = new RegressionTests.AlgorithmStatisticsTestParameters(algorithm,
                new Dictionary<string, string>(),
                Language.CSharp,
                AlgorithmStatus.Completed);


            // The AlgorithmRunner uses the `RegressionResultHandler` but only if HighFidelityLogging is enabled.
            // Otherwise, it defaults to the behavior of the `BacktestingResultHandler` class in `results.ProcessSynchronousEvents()`
            AlgorithmRunner.RunLocalBacktest(parameter.Algorithm,
                parameter.Statistics,
                parameter.AlphaStatistics,
                parameter.Language,
                parameter.ExpectedFinalStatus,
                startDate: new DateTime(2013, 10, 7),
                endDate: new DateTime(2013, 10, 11),
                storeResult: true);

            Assert.IsTrue(AlgorithmRunner.AlgorithmResults.ContainsKey(Language.CSharp));
            Assert.IsTrue(AlgorithmRunner.AlgorithmResults[Language.CSharp].ContainsKey(algorithm));

            var backtestResults = AlgorithmRunner.AlgorithmResults[Language.CSharp][algorithm];

            var benchmarkSeries = backtestResults.Charts["Benchmark"].Series["Benchmark"];
            var equitySeries = backtestResults.Charts["Strategy Equity"].Series["Equity"];
            var performanceSeries = backtestResults.Charts["Strategy Equity"].Series["Daily Performance"];
            var benchmark = ToDeedleSeries(benchmarkSeries);
            var equity = ToDeedleSeries(equitySeries);
            var performance = ToDeedleSeries(performanceSeries).SelectValues(x => x / 100);

            var equityPerformance = equity.ResampleEquivalence(dt => dt.Date, s => s.LastValue()).PercentChange();
            var benchmarkPerformance = benchmark.ResampleEquivalence(dt => dt.Date, s => s.LastValue()).PercentChange();

            // Uncomment the lines below to simulate a (naive) data cleaning attempt.
            // Remarks: during the development of PR #3979, this was thought to be a solution for misaligned values.
            // however, because the lowest resolution of an algorithm can affect the result of the performance series, we quickly
            // discovered that this was not an apt solution. You can view the misalignment with non-daily data
            // by uncommenting the lines below. The test should fail on the "diverging values" test for any algorithm that makes use of minutely data.
            // However, the test will pass for algorithms that only make use of daily resolution because the benchmark
            // is added in daily resolution in 'Engine/DataFeeds/UniverseSelection.cs#L384', which causes the sampling
            // of the two series to be aligned with each other (sampling at the previous close, which is 2 days ago w/ daily data vs. yesterday's close w/ non-daily).
            // --------------------------------------------------------------
            //performanceSeries.Values.RemoveAt(0);
            //performanceSeries.Values.RemoveAt(0);
            //equityPerformance = equityPerformance.After(equityPerformance.GetKeyAt(1));
            //benchmarkPerformance = benchmarkPerformance.After(benchmarkPerformance.GetKeyAt(1));
            //---------------------------------------------------------------

            //Frame.CreateEmpty<DateTime, string>().Join("equity", equityPerformance).Join("bench", benchmarkPerformance).Join("perf", performance).Print();
            // As of 2020-01-10, by uncommenting the line above, it produces this Frame in master for `BasicTemplateDailyAlgorithm`:
            //
            // ===================================================================================
            // |                           equity               bench                perf        |
            // | 10/7/2013 12:00:00 AM  -> <missing>            <missing>            0           |
            // | 10/8/2013 12:00:00 AM  -> 0                    -0.00835042494111074 0           |
            // | 10/9/2013 12:00:00 AM  -> -0.0114551489999999  -0.0117645982503731  -0.01145515 |
            // | 10/10/2013 12:00:00 AM -> 0.000601820948637848 0.000604391026446548 0.000601821 |
            // | 10/11/2013 12:00:00 AM -> 0.0215322328286752   0.0216206928455305   0.02153223  |
            // | 10/12/2013 12:00:00 AM -> 0.00635883739965527  0.00638464683264607  0.006358837 |
            // ===================================================================================
            //
            // And it produces this Frame in master for `BasicTemplateAlgorithm` (minute resolution):
            //
            // ====================================================================================
            // |                           equity               bench                perf         |
            // | 10/7/2013 12:00:00 AM  -> <missing>            <missing>            2.69427E-05  |
            // | 10/8/2013 12:00:00 AM  -> -0.0117197472348503  -0.00835042494111074 -0.01171975  |
            // | 10/9/2013 12:00:00 AM  -> 0.000601965859025514 -0.0117645982503731  0.0006019659 |
            // | 10/10/2013 12:00:00 AM -> 0.0215374143815271   0.000604391026446548 0.02153741   |
            // | 10/11/2013 12:00:00 AM -> 0.00636033533927404  0.0216206928455305   0.006360335  |
            // | 10/12/2013 12:00:00 AM -> 0                    0.00638464683264607  0            |
            // ====================================================================================
            //
            // Note: The `<missing>` values at the start of the "bench" series (10/7/2013 12:00:00 AM) would
            // be represented as a `0` due to the `CreateBenchmarkDifferences(...)` method in StatisticsBuilder.
            // The `EnsureSameLength(...)` method in StatisticsBuilder pads the result with
            // additional zeroes by appending if the length of the two series are not equal, but that is not the case here.
            //
            // We'll be calculating statistics for the daily algorithm using these two series:
            //        Bench, Performance
            // [[         0,          0], // Invalid, this is the first time step of the algorithm. No data has been pumped in yet nor have the securities' prices been initialized. This value shouldn't exist.
            //  [-0.0083504,          0], // Invalid, no data should exist for this day in "Bench" because we don't calculate the percentage change from open to close. This value should exist, but we should drop it for the time being.
            //  [-0.0117645, -0.0114551],
            //  [0.00060439, 0.00060182],
            //  [0.02162069, 0.02153223],
            //  [0.00638464, 0.00635883]]
            //
            // If we manually calculate the beta with the series put above,  we get the beta: 0.8757695
            // If we manually calculate the beta without the invalid values, we get the beta: 0.9892104

            Assert.AreEqual(
                equityPerformance.ValueCount,
                performance.ValueCount,
                "Calculated equity performance series or performance series contains more values than expected"
            );
            Assert.AreEqual(
                equityPerformance.Values.Select(x => Math.Round(x, 5)).ToList(), performance.Values.Select(x => Math.Round(x, 5)).ToList(),
                "Calculated equity performance value does not match performance series value. This most likely means that the performance series has been sampled more than it should have and is misaligned as a result."
            );
            Assert.AreEqual(
                performance.ValueCount,
                benchmarkPerformance.ValueCount,
                "Performance and benchmark performance series are misaligned"
            );
            Assert.IsTrue(
                (performance - benchmarkPerformance).Values.All(x => x <= 0.0005 && x >= -0.0005),
                "Equity performance and benchmark performance have diverging values. This most likely means that the performance and calculated benchmark performance series are misaligned."
            );

            // Clean up the static AlgorithmResults dictionary once we're done testing to free up memory
            AlgorithmRunner.AlgorithmResults[Language.CSharp].Remove(algorithm);
        }

        private static Series<DateTime, double> ToDeedleSeries(Series series)
        {
            return new Series<DateTime, double>(series.Values.Select(x => new KeyValuePair<DateTime, double>(Time.UnixTimeStampToDateTime(x.x), (double)x.y)));
        }
    }
}
