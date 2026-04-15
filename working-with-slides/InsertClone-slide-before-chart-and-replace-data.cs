using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Define file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";
            var workbookPath = "data.xlsx";

            // Verify input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found.");
                return;
            }

            // Verify external workbook exists (optional, handle exception later)
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("External workbook not found.");
                // Continue; SetExternalWorkbook will handle missing workbook if needed
            }

            try
            {
                // Load the presentation
                using (var pres = new Aspose.Slides.Presentation(inputPath))
                {
                    var slides = pres.Slides;
                    int chartSlideIndex = -1;
                    Aspose.Slides.Charts.IChart chart = null;

                    // Locate the first slide containing a chart
                    for (int i = 0; i < slides.Count; i++)
                    {
                        var slide = slides[i];
                        foreach (var shape in slide.Shapes)
                        {
                            chart = shape as Aspose.Slides.Charts.IChart;
                            if (chart != null)
                            {
                                chartSlideIndex = i;
                                break;
                            }
                        }
                        if (chartSlideIndex != -1)
                            break;
                    }

                    if (chartSlideIndex == -1)
                    {
                        Console.WriteLine("No chart found in the presentation.");
                        return;
                    }

                    // Clone the slide containing the chart and insert before it
                    var sourceSlide = slides[chartSlideIndex];
                    slides.InsertClone(chartSlideIndex, sourceSlide);

                    // After insertion, the original chart slide is now at chartSlideIndex + 1
                    var targetSlide = slides[chartSlideIndex + 1];
                    Aspose.Slides.Charts.IChart targetChart = null;

                    // Find the chart in the target slide
                    foreach (var shape in targetSlide.Shapes)
                    {
                        targetChart = shape as Aspose.Slides.Charts.IChart;
                        if (targetChart != null)
                            break;
                    }

                    if (targetChart != null)
                    {
                        // Replace chart data source with external workbook
                        var chartData = targetChart.ChartData;
                        ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath, true);
                    }
                    else
                    {
                        Console.WriteLine("Chart not found in the cloned slide.");
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (InvalidOperationException ex)
            {
                // Handle unsupported format or external workbook issues
                Console.WriteLine("Operation failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}