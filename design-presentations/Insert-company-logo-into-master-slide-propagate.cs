// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Insert company logo into master slide and propagate using C#

//

// Description:

// Demonstrates how to insert a company logo onto the master slide of a new

// presentation so that it appears on all derived slides, using Aspose.Slides for

// .NET. The example loads an image file, adds it to the presentation, places it

// on the master slide, and saves the resulting PPTX file.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Insert Logo, Master Slide, Presentation

// Automation, .NET

//

// Use Cases:

// - Automate adding a company logo to every slide via the master slide.

// - Build .NET tools for consistent branding across PowerPoint presentations.

// - Generate or modify PPTX files programmatically with Aspose.Slides.

// - Validate and test presentation workflows before distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Paths

        string dataDir = "Data";

        string imageFileName = "logo.png";

        string outputFile = "PresentationWithLogo.pptx";



        // Ensure data directory exists

        if (!Directory.Exists(dataDir))

        {

            Directory.CreateDirectory(dataDir);

        }



        string imagePath = Path.Combine(dataDir, imageFileName);



        // Verify image file exists

        if (!File.Exists(imagePath))

        {

            Console.WriteLine("Image file not found: " + imagePath);

            return;

        }



        // Create a new presentation

        var pres = new Presentation();



        // Add image to presentation

        var imageBytes = File.ReadAllBytes(imagePath);

        var img = pres.Images.AddImage(imageBytes);



        // Get master slide from the first slide's layout

        var masterSlide = pres.Slides[0].LayoutSlide.MasterSlide;



        // Insert logo onto master slide (will appear on all derived slides)

        masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, img.Width, img.Height, img);



        // Save presentation

        pres.Save(outputFile, SaveFormat.Pptx);

        pres.Dispose();

    }

}

