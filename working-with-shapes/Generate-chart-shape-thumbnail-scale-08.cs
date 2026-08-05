// -----------------------------------------------------------------------------
// Example: Generate chart shape thumbnail scale 08 using C#
//
// Description:
// Demonstrates how to generate chart shape thumbnails with a scaling factor
// of 0.8 (both X and Y) using C# and Aspose.Slides for .NET. The example loads a
// PowerPoint presentation, extracts chart shapes from the first slide, creates
// scaled thumbnail images for each chart, saves the images to an output folder,
// and finally saves the (unchanged) presentation. This pattern helps automate
// PPTX workflows that require chart image extraction with custom scaling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, Chart, Shape,
// Thumbnail, Scale, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of chart shape thumbnails with custom scaling.
// - Build C# utilities for extracting and processing chart images from PPTX files.
// - Integrate chart thumbnail creation into .NET applications or CI pipelines.
// - Validate and preview chart visuals before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDirectory = "output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            ISlide slide = presentation.Slides[0];
            int chartIndex = 0;

            foreach (IShape shape in slide.Shapes)
            {
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    float scaleX = 0.8f;
                    float scaleY = 0.8f;
                    IImage image = chart.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);
                    string imagePath = Path.Combine(outputDirectory, $"Chart_{slide.SlideNumber}_{chartIndex}.jpg");
                    image.Save(imagePath, ImageFormat.Jpeg);
                    image.Dispose();
                    chartIndex++;
                }
            }

            presentation.Save("output.pptx", SaveFormat.Pptx);
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
