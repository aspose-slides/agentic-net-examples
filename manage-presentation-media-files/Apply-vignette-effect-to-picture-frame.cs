// -----------------------------------------------------------------------------
// Example: Apply vignette effect to picture frame using C#
//
// Description:
// Demonstrates how to apply a vignette effect to a picture frame in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads an existing
// presentation (or creates a new one), inserts an image as a picture frame, and
// adds a radial gradient fill overlay to simulate a vignette. The resulting
// presentation is saved as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Vignette, Effect, Picture Frame,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding vignette effect to images in PowerPoint slides.
// - Build .NET tools for enhancing slide visuals programmatically.
// - Generate or transform PPTX files with custom visual effects.
// - Validate presentation styling before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string imagePath = "image.jpg";
        string outputPath = "output_vignette.pptx";

        Aspose.Slides.Presentation presentation = null;
        try
        {
            if (File.Exists(presentationPath))
            {
                presentation = new Aspose.Slides.Presentation(presentationPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        Aspose.Slides.ISlide slide = presentation.Slides[0];

        if (File.Exists(imagePath))
        {
            Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(image);
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, ppImage.Width, ppImage.Height, ppImage);

            // Enable fill overlay effect to create vignette
            pictureFrame.EffectFormat.EnableFillOverlayEffect();
            Aspose.Slides.Effects.IFillOverlay fillOverlay = pictureFrame.EffectFormat.FillOverlayEffect;

            // Set gradient fill for overlay (radial gradient from transparent center to black edges)
            fillOverlay.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            fillOverlay.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Radial;
            fillOverlay.FillFormat.GradientFormat.GradientStops.Add(0.0f, Aspose.Slides.PresetColor.White);
            fillOverlay.FillFormat.GradientFormat.GradientStops.Add(1.0f, Aspose.Slides.PresetColor.Black);
        }
        else
        {
            Console.WriteLine("Image file not found: " + imagePath);
        }

        // Save presentation before exit
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
