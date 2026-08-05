// -----------------------------------------------------------------------------
// Example: Export slide to BMP with 300 DPI using C#
//
// Description:
// Demonstrates how to export the first slide of a PowerPoint presentation
// to a BMP image at 300 DPI using C# and Aspose.Slides for .NET. The example
// shows the required presentation‑processing steps, including loading a PPTX,
// calculating the scaling factor for high‑resolution output, generating the
// image, and saving both the BMP and a copy of the original presentation.
// Developers can use this pattern to automate high‑resolution slide image
// extraction, integrate slide rendering into .NET applications, or validate
// presentation workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, BMP, 300 DPI,
// Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of a slide to BMP with 300 DPI for publishing or printing.
// - Build C# utilities that generate high‑resolution slide images from PPTX files.
// - Integrate slide rendering into .NET applications that require bitmap output.
// - Validate and test presentation processing pipelines before deployment.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputBmpPath = "slide1.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Calculate scaling factor for 300 DPI (default DPI is 96)
            float scale = 300f / 96f;

            // Generate the image with the calculated scale
            Aspose.Slides.IImage image = slide.GetImage(scale, scale);

            // Save the image as BMP
            image.Save(outputBmpPath, Aspose.Slides.ImageFormat.Bmp);

            // Save the presentation before exiting (no modifications made)
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            image.Dispose();
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
