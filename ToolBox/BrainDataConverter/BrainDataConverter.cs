using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantConnect.Data;
using QuantConnect.Data.Custom.BrainData;
using QuantConnect.Logging;

namespace QuantConnect.ToolBox.BrainDataConverter
{
    public class BrainDataConverter : ToolBoxDataConverter
    {
        /// <summary>
        /// Creates an instance of the object. Note: construct your <see cref="DirectoryInfo"/> instance
        /// to point at the `braindata` folder, but don't specify the sentiment or stock ranking folders
        /// </summary>
        /// <param name="sourceDirectory">Directory where we load raw data from</param>
        /// <param name="destinationDirectory">The data's final destination directory</param>
        public BrainDataConverter(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory, string market = Market.USA)
            : base(sourceDirectory, destinationDirectory, market)
        {
        }

        /// <summary>
        /// Converts the data by date
        /// </summary>
        /// <param name="date">Date to convert data from</param>
        /// <returns>Boolean value indicating success status</returns>
        public override bool Convert(DateTime date)
        {
            var success = true;

            var sentimentSourceFile = new FileInfo(Path.Combine(SourceDirectory.FullName, "sentiment", $"sent_us_ndays_7_{date:yyyyMMdd}.csv"));
            var sentimentFinalDirectory = new DirectoryInfo(Path.Combine(DestinationDirectory.FullName, "sentiment"));
            var rankingsSourceFile = new FileInfo(Path.Combine(SourceDirectory.FullName, "rankings", $"ml_alpha_10_days_{date:yyyyMMdd}.csv"));
            var rankingsFinalDirectory = new DirectoryInfo(Path.Combine(DestinationDirectory.FullName, "rankings"));

            // Create the directories so that we don't get an error if we try to move a file to a non-existant directory
            sentimentFinalDirectory.Create();
            rankingsFinalDirectory.Create();

            // Attempt to parse and write both files before we give up
            try
            {
                WriteToFile(
                    Process<BrainDataSentiment>(date, sentimentSourceFile),
                    sentimentFinalDirectory
                );
            }
            catch (Exception e)
            {
                Log.Error(e, $"BrainDataConverter.Convert(): Failed to process sentiment data: {sentimentSourceFile.FullName}");
                success = false;
            }

            /*
            try
            {
                WriteToFile(
                    Process<BrainDataRanking>(date, rankingsSourceFile),
                    rankingsFinalFile
                );
            }
            catch (Exception e)
            {
                Log.Error(e, $"BrainDataConverter.Convert(): Failed to process rankings data: {rankingsSourceFile.FullName}");
                success = false;
            }
            */

            return success;
        }
    }
}
