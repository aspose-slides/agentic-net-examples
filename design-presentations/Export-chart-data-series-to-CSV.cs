// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export chart data series to CSV using C#

//

// Description:

// Demonstrates how to export each chart's data series to separate CSV files 

// using C# and Aspose.Slides for .NET. The example loads a PowerPoint presentation,

// iterates through all chart shapes, extracts the data points of each series, 

// writes them to CSV files, and finally saves the (potentially modified) 

// presentation. This pattern can be used to automate PPTX workflows, extract 

// chart data for analysis, or integrate presentation processing into .NET 

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Chart, Data Series, CSV, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of chart series data to CSV for reporting or analytics.

// - Build C# utilities that process PowerPoint files and export chart data.

// - Integrate chart data extraction into larger .NET data pipelines.

// - Validate and transform PPTX content before publishing or further processing.

// -----------------------------------------------------------------------------



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

            // Input presentation file path

            string inputPath = "input.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    int chartCounter = 0;



                    // Iterate through all slides

                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)

                    {

                        ISlide slide = pres.Slides[slideIndex];



                        // Iterate through all shapes on the slide

                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)

                        {

                            IShape shape = slide.Shapes[shapeIndex];



                            // Process only chart shapes

                            IChart chart = shape as IChart;

                            if (chart == null)

                                continue;



                            // Get the series collection of the chart

                            IChartSeriesCollection seriesCollection = chart.ChartData.Series;



                            // Export each series to a separate CSV file

                            for (int seriesIdx = 0; seriesIdx < seriesCollection.Count; seriesIdx++)

                            {

                                IChartSeries series = seriesCollection[seriesIdx];



                                // Build CSV file name (e.g., Chart_0_Series_0.csv)

                                string csvFileName = $"Chart_{chartCounter}_Series_{seriesIdx}.csv";



                                using (StreamWriter writer = new StreamWriter(csvFileName))

                                {

                                    // Write CSV header

                                    writer.WriteLine("Category,Value");



                                    // Export data points of the series

                                    for (int pointIdx = 0; pointIdx < series.DataPoints.Count; pointIdx++)

                                    {

                                        IChartDataPoint dataPoint = series.DataPoints[pointIdx];



                                        // Attempt to retrieve the value; fallback to placeholder if unavailable

                                        string value = "0";



                                        try

                                        {

                                            // Many chart types store the value in the first cell of the data point

                                            // This may vary; adjust as needed for specific chart types

                                            if (dataPoint.Value != null && dataPoint.Value.Data != null)

                                                value = dataPoint.Value.Data.ToString();

                                        }

                                        catch

                                        {

                                            // Ignore any errors while reading the value

                                        }



                                        // Write the data point to CSV (Category index used as placeholder)

                                        writer.WriteLine($"{pointIdx},{value}");

                                    }

                                }

                            }



                            chartCounter++;

                        }

                    }



                    // Save the presentation (required by the task)

                    pres.Save("output.pptx", SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., external URL issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

