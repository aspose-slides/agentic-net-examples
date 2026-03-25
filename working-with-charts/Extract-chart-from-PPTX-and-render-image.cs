using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputImagePath = "chart.png";
        string outputPresentationPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.Charts.IChart chart = null;

                // Find the first chart shape on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    chart = shape as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found in the presentation.");
                }
                else
                {
                    // Render the chart to an image preserving visual fidelity
                    Aspose.Slides.IImage chartImage = chart.GetImage();
                    chartImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                    chartImage.Dispose();
                    Console.WriteLine("Chart image saved to " + outputImagePath);
                }

                // Save the presentation before exiting
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}