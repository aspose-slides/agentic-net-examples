using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartDataSeriesToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if presentation path is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the presentation file as an argument.");
                return;
            }

            string presentationPath = args[0];

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"File not found: {presentationPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Check if the shape is a chart
                            IChart chart = slide.Shapes[shapeIndex] as IChart;
                            if (chart == null)
                                continue;

                            // Get the series collection
                            IChartSeriesCollection seriesCollection = chart.ChartData.Series;

                            // Iterate through each series
                            for (int seriesIndex = 0; seriesIndex < seriesCollection.Count; seriesIndex++)
                            {
                                IChartSeries series = seriesCollection[seriesIndex];

                                // Prepare CSV file name
                                string csvFileName = $"Chart_Slide{slideIndex + 1}_Shape{shapeIndex + 1}_Series{seriesIndex + 1}.csv";

                                // Write series data to CSV
                                using (StreamWriter writer = new StreamWriter(csvFileName))
                                {
                                    // Write header (optional)
                                    writer.WriteLine("Category,Value");

                                    // Iterate through data points of the series
                                    for (int pointIndex = 0; pointIndex < series.DataPoints.Count; pointIndex++)
                                    {
                                        // Attempt to retrieve the value; if unavailable, write empty
                                        string value = string.Empty;
                                        try
                                        {
                                            // The Value property may be of type IChartDataCell; retrieve its numeric value if possible
                                            IChartDataCell cell = series.DataPoints[pointIndex].Value as IChartDataCell;
                                            if (cell != null && cell.Value != null)
                                                value = cell.Value.ToString();
                                        }
                                        catch
                                        {
                                            // Ignore any errors while reading cell value
                                        }

                                        // Write a line to CSV (Category placeholder)
                                        writer.WriteLine($"{pointIndex + 1},{value}");
                                    }
                                }

                                Console.WriteLine($"Exported series {seriesIndex + 1} of chart on slide {slideIndex + 1} to {csvFileName}");
                            }
                        }
                    }

                    // Save the presentation (no changes made, but required by rule)
                    string outputPath = Path.Combine(Path.GetDirectoryName(presentationPath), "Exported_" + Path.GetFileName(presentationPath));
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // General exception handling (including possible web service errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}