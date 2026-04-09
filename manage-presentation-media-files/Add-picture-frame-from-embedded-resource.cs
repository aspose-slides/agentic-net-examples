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