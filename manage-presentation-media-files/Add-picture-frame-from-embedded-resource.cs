// -----------------------------------------------------------------------------
// Example: Add picture frame from embedded resource using C#
//
// Description:
// Demonstrates how to add a picture frame to a slide using an image that is
// embedded as a resource in the assembly. The example creates a new presentation,
// retrieves the embedded PNG image, adds it to the presentation's image collection,
// and inserts a picture frame that covers the entire slide. The resulting PPTX
// file is saved to the current directory.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Embedded Resource, Image, Picture Frame,
// Presentation Generation, .NET Automation
//
// Use Cases:
// - Insert images packaged within an application into PowerPoint slides.
// - Build .NET tools that generate presentations with embedded assets.
// - Automate creation of slide decks without external image files.
// - Ensure consistent branding by using embedded resources for graphics.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide (creates one by default)
        var slide = presentation.Slides[0];

        // Name of the embedded image resource (adjust namespace and folder as needed)
        var resourceName = "MyNamespace.Resources.SampleImage.png";

        // Load the embedded image stream from the assembly
        var assembly = Assembly.GetExecutingAssembly();
        using (var imageStream = assembly.GetManifestResourceStream(resourceName))
        {
            if (imageStream == null)
            {
                Console.WriteLine("Embedded resource not found: " + resourceName);
                return;
            }

            // Add the image to the presentation's image collection
            var pictureImage = presentation.Images.AddImage(imageStream);

            // Add a picture frame that fills the entire slide
            slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                0,
                0,
                presentation.SlideSize.Size.Width,
                presentation.SlideSize.Size.Height,
                pictureImage);
        }

        // Define output file path
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EmbeddedImagePresentation.pptx");

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}
