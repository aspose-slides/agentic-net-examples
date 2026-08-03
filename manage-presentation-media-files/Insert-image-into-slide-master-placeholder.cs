// -----------------------------------------------------------------------------
// Example: Insert image into slide master placeholder using C#
//
// Description:
// Demonstrates how to insert an image into a slide master picture placeholder 
// using C# and Aspose.Slides for .NET. The example loads a template presentation,
// adds a picture placeholder to a blank layout on the master slide, assigns an 
// external image to the placeholder, and saves the modified presentation. This 
// pattern can be used to automate PowerPoint slide master modifications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Image, Slide, Master, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of images into slide master placeholders.
// - Build tools for PowerPoint presentation templating in .NET.
// - Generate or modify PPTX files programmatically.
// - Prepare slide masters for consistent branding across presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input presentation, image, and output presentation
        string inputPath = "template.pptx";
        string imagePath = "image.jpg";
        string outputPath = "output.pptx";

        // Verify that input files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found.");
            return;
        }
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found.");
            return;
        }

        try
        {
            // Load the source presentation
            Presentation pres = new Presentation(inputPath);

            // Get the first master slide
            IMasterSlide master = pres.Masters[0];

            // Get a blank layout slide from the master
            ILayoutSlide layout = master.LayoutSlides.GetByType(SlideLayoutType.Blank);

            // Add a picture placeholder to the layout slide
            IAutoShape placeholder = layout.PlaceholderManager.AddPicturePlaceholder(50, 50, 400, 300);

            // Load image data and add it to the presentation's image collection
            byte[] imageData = File.ReadAllBytes(imagePath);
            IPPImage img = pres.Images.AddImage(imageData);

            // Set the placeholder's fill to the image (updates all linked slides)
            placeholder.FillFormat.PictureFillFormat.Picture.Image = img;

            // Save the updated presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
