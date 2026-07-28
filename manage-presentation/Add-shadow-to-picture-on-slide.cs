// -----------------------------------------------------------------------------
// Example: Add shadow to picture on slide using C#
//
// Description:
// Demonstrates how to add an outer shadow effect to a picture on a slide 
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// inserts an image as a picture frame, applies an outer shadow with custom 
// properties, and saves the result as a PPTX file. This pattern can be used 
// to automate PowerPoint visual enhancements in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Shadow, Picture, Slide, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding outer shadow effects to pictures in presentations.
// - Build C# tools for enhancing visual appearance of PowerPoint slides.
// - Generate or modify PPTX files with custom picture styling in .NET.
// - Validate presentation rendering before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string imagePath = "sample.jpg";
        string outputPath = "output.pptx";

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                // Load image into the presentation
                IPPImage image;
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    image = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
                }

                // Add picture frame to the slide
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 300, image);

                // Enable outer shadow effect
                pictureFrame.EffectFormat.EnableOuterShadowEffect();

                // Configure shadow properties
                pictureFrame.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                pictureFrame.EffectFormat.OuterShadowEffect.Direction = 45.0f;
                pictureFrame.EffectFormat.OuterShadowEffect.Distance = 3.0;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
