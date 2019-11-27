﻿/*
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

using System;
using System.Collections.Generic;
using QuantConnect.Packets;

namespace QuantConnect.Report.ReportElements
{
    /// <summary>
    /// Common interface for template elements of the report
    /// </summary>
    internal abstract class ReportElement : IReportElement
    {
        /// <summary>
        /// Name of this report element
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Template key code.
        /// </summary>
        public virtual string Key { get; protected set; }

        /// <summary>
        /// The generated output string to be injected
        /// </summary>
        public abstract string Render();

        /// <summary>
        /// Get the equity chart points
        /// </summary>
        /// <param name="result">Result object to extract the chart points</param>
        /// <returns></returns>
        public SortedList<DateTime, double> EquityPoints(Result result)
        {
            var points = new SortedList<DateTime, double>();

            foreach (var point in result.Charts["Strategy Equity"].Series["Equity"].Values)
            {
                points[Time.UnixTimeStampToDateTime(point.x)] = Convert.ToDouble(point.y);
            }

            return points;
        }

        /// <summary>
        /// Convert cumulative return to daily returns percentage
        /// </summary>
        /// <param name="chart"></param>
        /// <returns></returns>
        public SortedList<DateTime, double> EquityReturns(SortedList<DateTime, double> chart)
        {
            var returns = new SortedList<DateTime, double>();
            double previous = 0;
            foreach (var point in chart)
            {
                if (returns.Count == 0)
                {
                    returns.Add(point.Key, 0);
                    previous = point.Value;
                    continue;
                }

                var delta = (point.Value / previous) - 1;
                returns.Add(point.Key, delta);
            }
            return returns;
        }

        /// <summary>
        /// Gets the points of the benchmark
        /// </summary>
        /// <param name="result">Backtesting or live results</param>
        /// <returns>Sorted list keyed by date and value</returns>
        public SortedList<DateTime, double> BenchmarkPoints(Result result)
        {
            var points = new SortedList<DateTime, double>();

            foreach (var point in result.Charts["Benchmark"].Series["Benchmark"].Values)
            {
                points[Time.UnixTimeStampToDateTime(point.x)] = Convert.ToDouble(point.y);
            }

            return points;
        }
    }
}