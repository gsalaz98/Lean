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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using QuantConnect.Logging;
using Formatting = Newtonsoft.Json.Formatting;

namespace QuantConnect.Data.Custom.Sec
{
    public class SecReportFactory
    {
        /// <summary>
        /// Factory method creates SEC report by deserializing XML formatted SEC data to <see cref="SecReportCollection"/> 
        /// </summary>
        /// <param name="rawDataXmlFilePath">Path to XML file containing formatted SEC data</param>
        public ISecReport CreateSecReport(string rawDataXmlFilePath)
        {
            var secReportXml = new XmlDocument();

            try
            {
                secReportXml.Load(rawDataXmlFilePath);
            }
            catch (Exception)
            {
                Log.Error($"Failed to load XML file: {rawDataXmlFilePath}");
                throw;
            }

            var json = JsonConvert.SerializeXmlNode(secReportXml, Formatting.None, true);
            var secReportDocument = JsonConvert.DeserializeObject<SecReportSubmission>(json);

            var formType = secReportDocument.FType;

            switch (formType)
            {
                case "8-K":
                    return new SecReport8K(secReportDocument);
                case "10-K":
                    return new SecReport10K(secReportDocument);
                case "10-Q":
                    return new SecReport10Q(secReportDocument);
                default:
                    throw new DataException($"SEC form type {formType} is not supported at this time");
            }
        }

        /// <summary>
        /// Determines if the given line has a value associated with the tag
        /// </summary>
        /// <param name="line">Line of text from SEC report</param>
        /// <returns>Boolean indicating whether the line contains a value</returns>
        public bool HasValue(string line)
        {
            var tagEnd = line.IndexOf(">", StringComparison.Ordinal);

            if (!line.StartsWith("<") || tagEnd == -1)
            {
                return false;
            }

            return line.Length > tagEnd + 1;
        }
        
        /// <summary>
        /// Gets the line's value (if there is one)
        /// </summary>
        /// <param name="line">Line of text from SEC report</param>
        /// <returns>Value associated with the tag</returns>
        public string GetTagValueFromLine(string line)
        {
            return line.Substring(line.IndexOf(">", StringComparison.Ordinal) + 1);
        }

        /// <summary>
        /// Gets the tag name from a given line
        /// </summary>
        /// <param name="line">Line of text from SEC report</param>
        /// <returns>Tag name from the line</returns>
        public string GetTagNameFromLine(string line)
        {
            var start = line.IndexOf("<", StringComparison.Ordinal) + 1;
            var length = line.IndexOf(">", StringComparison.Ordinal) - start;

            if (start == -1 || length <= 0)
            {
                return string.Empty;
            }

            return line.Substring(start, length);
        }
    }
}
