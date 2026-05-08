using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation, output presentation, and chart image
        string inputPath = "input.pptx";
        string outputPresentationPath = "output.pptx";
        string chartImagePath = "chart.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Find the first chart on the first slide
            Aspose.Slides.Charts.IChart chart = null;
            foreach (Aspose.Slides.IShape shape in presentation.Slides[0].Shapes)
            {
                chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
            }
            else
            {
                // Export the chart as a high‑resolution PNG image
                Aspose.Slides.IImage chartImage = chart.GetImage();
                chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);
                chartImage.Dispose();
            }

            // Save the (potentially modified) presentation before exiting
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}