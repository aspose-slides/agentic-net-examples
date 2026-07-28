// -----------------------------------------------------------------------------
// Example: Export slide as JPEG 80 percent compression using C#
//
// Description:
// Demonstrates how to export the first slide of a PowerPoint presentation
// as a JPEG image with 80 % compression using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, renders the first slide to an image, saves
// the image with the specified quality, and then saves the original presentation.
// This pattern can be used to automate slide‑to‑image conversion in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Slide, Jpeg,
// Percent, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of a slide as a JPEG image with specific compression.
// - Build C# utilities for PowerPoint slide rendering and image generation.
// - Integrate slide‑to‑image conversion into .NET workflows.
// - Validate and process PPTX files before publishing or further integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputImagePath = "slide1.jpg";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            ISlide slide = presentation.Slides[0];
            IImage image = slide.GetImage(1f, 1f);
            image.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg, 80);
            // Save presentation before exit
            presentation.Save(inputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
