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
        static void Main()
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            if (pres.Slides.Count == 0)
            {
                Console.WriteLine("Presentation contains no slides.");
                pres.Dispose();
                return;
            }

            IChart chart = pres.Slides[0].Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                pres.Dispose();
                return;
            }

            string xmlPath = "chartData.xml";
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(xmlPath, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Chart");
                    writer.WriteAttributeString("Type", chart.Type.ToString());

                    foreach (IChartSeries series in chart.ChartData.Series)
                    {
                        writer.WriteStartElement("Series");

                        IStringChartValue seriesName = series.Name as IStringChartValue;
                        string seriesNameStr = "";
                        if (seriesName != null)
                        {
                            if (seriesName.DataSourceType == DataSourceType.StringLiterals)
                            {
                                seriesNameStr = seriesName.AsLiteralString;
                            }
                            else
                            {
                                seriesNameStr = seriesName.ToString();
                            }
                        }
                        writer.WriteAttributeString("Name", seriesNameStr);

                        int pointIndex = 0;
                        foreach (IChartDataPoint point in series.DataPoints)
                        {
                            writer.WriteStartElement("DataPoint");
                            writer.WriteAttributeString("Index", pointIndex.ToString());

                            object valueObj = point.Value.Data;
                            string valueStr = valueObj != null ? valueObj.ToString() : "";
                            writer.WriteAttributeString("Value", valueStr);

                            writer.WriteEndElement(); // DataPoint
                            pointIndex++;
                        }

                        writer.WriteEndElement(); // Series
                    }

                    writer.WriteEndElement(); // Chart
                    writer.WriteEndDocument();
                }

                Console.WriteLine("Chart data exported to XML: " + xmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting to XML: " + ex.Message);
            }

            // Save the presentation before exit
            try
            {
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            pres.Dispose();
        }
    }
}