using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ExportChartDataToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output XML path
            string outputXmlPath = "chartData.xml";
            // Output presentation path (save before exit)
            string outputPresentationPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Assume the first slide contains the chart
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                presentation.Dispose();
                return;
            }

            // Create XML writer
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(outputXmlPath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Chart");

                // Iterate over series
                IChartSeriesCollection seriesCollection = chart.ChartData.Series;
                for (int s = 0; s < seriesCollection.Count; s++)
                {
                    IChartSeries series = seriesCollection[s];

                    // Get series name as literal string
                    string seriesName = series.Name.AsLiteralString;

                    writer.WriteStartElement("Series");
                    writer.WriteAttributeString("Name", seriesName ?? string.Empty);

                    // Iterate over data points
                    IChartDataPointCollection dataPoints = series.DataPoints;
                    for (int p = 0; p < dataPoints.Count; p++)
                    {
                        IChartDataPoint dataPoint = dataPoints[p];

                        // The Value property implements IDoubleChartValue
                        IDoubleChartValue doubleValue = dataPoint.Value as IDoubleChartValue;
                        string valueString = string.Empty;

                        if (doubleValue != null)
                        {
                            // Use literal double value
                            valueString = doubleValue.AsLiteralDouble.ToString();
                        }
                        else
                        {
                            // Fallback: try to get string representation via IStringOrDoubleChartValue
                            IStringOrDoubleChartValue stringOrDouble = dataPoint.Value as IStringOrDoubleChartValue;
                            if (stringOrDouble != null)
                            {
                                // Prefer literal string if available
                                if (!string.IsNullOrEmpty(stringOrDouble.AsLiteralString))
                                {
                                    valueString = stringOrDouble.AsLiteralString;
                                }
                                else
                                {
                                    valueString = stringOrDouble.AsLiteralDouble.ToString();
                                }
                            }
                        }

                        writer.WriteStartElement("DataPoint");
                        writer.WriteString(valueString);
                        writer.WriteEndElement(); // DataPoint
                    }

                    writer.WriteEndElement(); // Series
                }

                writer.WriteEndElement(); // Chart
                writer.WriteEndDocument();
            }

            // Save the presentation (ensure it's saved before exit)
            try
            {
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested save format is not supported.");
            }
            finally
            {
                presentation.Dispose();
            }

            Console.WriteLine("Chart data exported to XML successfully.");
        }
    }
}