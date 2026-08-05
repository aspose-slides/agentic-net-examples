// -----------------------------------------------------------------------------
// Example: Add png to first master and save using C#
//
// Description:
// Demonstrates how to add a PNG image to the first master slide of a new
// presentation and save the result as a PPTX file using C# and Aspose.Slides
// for .NET. The example creates a presentation, inserts the image into the
// master slide's shape collection covering the entire slide area, and writes
// the output file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Master Slide, Add Image,
// Save Presentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a background PNG to the first master slide of presentations.
// - Build .NET tools for PowerPoint master slide customization.
// - Generate or modify PPTX files programmatically in C# applications.
// - Prepare presentation templates with predefined images before content creation.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputImagePath = "highres.png";
        string outputPath = "output.pptx";

        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine("Input image file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation())
            {
                // Add the PNG image to the presentation's image collection
                byte[] imageData = File.ReadAllBytes(inputImagePath);
                IPPImage image = presentation.Images.AddImage(imageData);

                // Get the first master slide
                IMasterSlide masterSlide = presentation.Masters[0];

                // Add the image as a picture frame covering the entire master slide
                masterSlide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    0,
                    0,
                    presentation.SlideSize.Size.Width,
                    presentation.SlideSize.Size.Height,
                    image);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
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
