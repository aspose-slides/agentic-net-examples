using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace BoxWhiskerChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine output file name
            string outputPath = "BoxWhiskerChart_out.pptx";

            // Create a new presentation or load an existing one if a file path is provided
            Presentation presentation;
            if (args.Length > 0)
            {
                string inputPath = args[0];
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Error: Input file \"{inputPath}\" not found.");
                    return;
                }

                try
                {
                    presentation = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading presentation: {ex.Message}");
                    return;
                }
            }
            else
            {
                presentation = new Presentation();
            }

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a Box‑and‑Whisker chart
            IChart chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 50f, 50f, 500f, 400f);

            // Clear default categories and series
            chart.ChartData.Categories.Clear();
            chart.ChartData.Series.Clear();

            // Get the chart data workbook and clear its default sheet
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            workbook.Clear(0);

            // Add categories
            workbook.GetCell(0, "A1", "Category 1");
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
            workbook.GetCell(0, "A2", "Category 2");
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
            workbook.GetCell(0, "A3", "Category 3");
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
            workbook.GetCell(0, "A4", "Category 4");
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
            workbook.GetCell(0, "A5", "Category 5");
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
            workbook.GetCell(0, "A6", "Category 6");
            chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

            // Add a series for the Box‑and‑Whisker chart
            IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);
            series.QuartileMethod = QuartileMethodType.Inclusive;
            series.ShowMeanLine = true;
            series.ShowMeanMarkers = true;
            series.ShowInnerPoints = true;
            series.ShowOutlierPoints = true;

            // Add data points for each category
            workbook.GetCell(0, "B1", 5.0);
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 5.0));
            workbook.GetCell(0, "B2", 7.5);
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 7.5));
            workbook.GetCell(0, "B3", 6.0);
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 6.0));
            workbook.GetCell(0, "B4", 8.2);
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 8.2));
            workbook.GetCell(0, "B5", 4.3);
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 4.3));
            workbook.GetCell(0, "B6", 9.1);
            series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 9.1));

            // Save the presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved successfully to \"{outputPath}\".");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving presentation: {ex.Message}");
            }
        }
    }
}