using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation, output folder for chart images, and output presentation
        string inputPath = "input.pptx";
        string outputDir = "ChartImages";
        string outputPresentationPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Create the output directory if it does not exist
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            int chartCounter = 0;

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    IChart chart = shape as IChart;

                    // If the shape is a chart, export it as an image
                    if (chart != null)
                    {
                        IImage chartImage = chart.GetImage();
                        string chartImagePath = Path.Combine(outputDir, $"Chart_Slide{slideIndex + 1}_{chartCounter + 1}.png");
                        chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);
                        chartCounter++;
                    }
                }
            }

            // Save the (potentially unchanged) presentation before exiting
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}