using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace PieChartUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: presentation file path and external workbook path
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: PieChartUpdater <presentation.pptx> <workbook.xlsx>");
                return;
            }

            string presentationPath = args[0];
            string workbookPath = args[1];

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"Error: Presentation file not found at '{presentationPath}'.");
                return;
            }

            // Verify that the workbook file exists
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine($"Error: Workbook file not found at '{workbookPath}'.");
                return;
            }

            try
            {
                // Load the existing presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Access the first slide (or create one if none exist)
                    ISlide slide;
                    if (presentation.Slides.Count > 0)
                    {
                        slide = presentation.Slides[0];
                    }
                    else
                    {
                        slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                    }

                    // Add a new pie chart with sample data and initialize it
                    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

                    // Bind the chart to an external workbook and update chart data
                    IChartData chartData = chart.ChartData;
                    ((ChartData)chartData).SetExternalWorkbook(workbookPath, true);

                    // Enable data labels and callouts for the first series
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                    // Save the updated presentation (overwrites the original file)
                    presentation.Save(presentationPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}