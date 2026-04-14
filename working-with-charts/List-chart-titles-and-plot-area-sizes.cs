using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file '{inputPath}' does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.Charts.IChart chart)
                        {
                            string title = chart.HasTitle && chart.ChartTitle != null
                                ? chart.ChartTitle.TextFrameForOverriding?.Text
                                : "(No Title)";

                            // Ensure layout is calculated to get actual dimensions
                            chart.ValidateChartLayout();

                            float plotWidth = chart.PlotArea.ActualWidth;
                            float plotHeight = chart.PlotArea.ActualHeight;

                            Console.WriteLine($"Slide {slide.SlideNumber}: Chart Title = '{title}', Plot Area Size = {plotWidth} x {plotHeight} points");
                        }
                    }
                }

                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}