// -----------------------------------------------------------------------------
// Example: Set custom percentage symbol for chart data labels using C#
//
// Description:
// Demonstrates how to customize the percentage symbol displayed on data labels
// of a percent‑stacked column chart using C# and Aspose.Slides for .NET. The
// example creates a new presentation, adds a chart, populates series data,
// enables percentage display on data labels, applies a custom number format
// (e.g., replacing '%' with '‰'), and saves the result as a PPTX file. This
// pattern can be used to automate chart formatting tasks in PowerPoint files.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Chart, Percent Stacked Column,
// Data Labels, Percentage Symbol, NumberFormat, Presentation Automation
//
// Use Cases:
// - Customize percentage symbols on chart data labels.
// - Automate chart formatting in PowerPoint presentations.
// - Build .NET tools for generating or modifying PPTX charts.
// - Apply custom number formats to data labels for branding or localization.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "SetPercentageSymbol_out.pptx";

            // Ensure the directory for the output file exists
            try
            {
                string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create output directory: " + ex.Message);
                return;
            }

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a percent stacked column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.PercentsStackedColumn,
                    50f, 50f, 500f, 400f);

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get default worksheet index
                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add a series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                    chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

                // Populate series data
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 35));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 45));

                // Show percentage values on data labels
                series.Labels.DefaultDataLabelFormat.ShowPercentage = true;

                // Customize the percentage symbol using a custom number format
                // Here we replace the default '%' with '‰' as an example
                series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0‰";

                // Save the presentation
                try
                {
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle format not supported or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}
