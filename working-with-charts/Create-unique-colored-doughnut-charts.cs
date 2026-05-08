using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output folder
            string outputFolder = "OutputCharts";
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Sample data sets for multiple presentations
            double[][] dataSets = new double[][]
            {
                new double[] { 30.0, 20.0, 50.0 },
                new double[] { 10.0, 40.0, 50.0 },
                new double[] { 25.0, 35.0, 40.0 }
            };

            // Loop through each data set and create a presentation
            for (int i = 0; i < dataSets.Length; i++)
            {
                string presentationPath = Path.Combine(outputFolder, $"DoughnutChart_{i + 1}.pptx");

                try
                {
                    // Create a new presentation
                    using (Presentation pres = new Presentation())
                    {
                        // Access the first slide
                        ISlide slide = pres.Slides[0];

                        // Add a doughnut chart
                        IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50f, 50f, 500f, 400f);

                        // Clear default series and categories
                        chart.ChartData.Series.Clear();
                        chart.ChartData.Categories.Clear();

                        // Add a new series
                        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                        IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.Doughnut);

                        // Ensure the data points accept double literals
                        series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;

                        // Populate the series with data points
                        foreach (double value in dataSets[i])
                        {
                            series.DataPoints.AddDataPointForDoughnutSeries(value);
                        }

                        // Set a unique hole size for each chart (example: 40%)
                        series.ParentSeriesGroup.DoughnutHoleSize = 40;

                        // Enable varied colors so each slice gets a distinct color
                        series.ParentSeriesGroup.IsColorVaried = true;

                        // Optionally set a title
                        chart.HasTitle = true;
                        chart.ChartTitle.AddTextFrameForOverriding($"Doughnut Chart {i + 1}");
                        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
                        chart.ChartTitle.Height = 20;

                        // Save the presentation
                        pres.Save(presentationPath, SaveFormat.Pptx);
                    }
                }
                catch (ArgumentException ex) when (ex.Message.Contains("DataSourceTypeForValues"))
                {
                    // Handle the specific data source type exception
                    Console.WriteLine($"Data source type error in presentation {presentationPath}: {ex.Message}");
                }
                catch (NotSupportedException ex)
                {
                    // Handle unsupported format exception
                    Console.WriteLine($"Format not supported for file {presentationPath}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file I/O, external services)
                    Console.WriteLine($"Unexpected error while creating {presentationPath}: {ex.Message}");
                }
            }
        }
    }
}