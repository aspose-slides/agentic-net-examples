// -----------------------------------------------------------------------------
// Example: Render SmartArt diagram to PNG with transparency using C#
//
// Description:
// Demonstrates how to render a SmartArt diagram to a PNG image with a transparent
// background using C# and Aspose.Slides for .NET. The example creates a new
// presentation, sets the slide background to transparent, adds a SmartArt shape,
// renders the SmartArt to an image, saves the PNG file, and finally saves the
// presentation file.
//
// Keywords:
// C#, Aspose.Slides, SmartArt, PNG, Transparency, Render, Presentation, .NET,
// PowerPoint, Image Export, Slide Background
//
// Use Cases:
// - Automate rendering of SmartArt diagrams to PNG images with transparent backgrounds.
// - Generate image assets from PowerPoint presentations for web or UI integration.
// - Build .NET tools that extract visual elements from PPTX files.
// - Validate and process SmartArt content programmatically before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace RenderSmartArtToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Set slide background to transparent (no fill)
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.NoFill;

            // Add a SmartArt diagram to the slide
            ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0f,               // X position
                0f,               // Y position
                400f,             // Width
                400f,             // Height
                SmartArtLayoutType.BasicBlockList);

            // Optionally customize the SmartArt (quick style, color, etc.)
            // smartArt.QuickStyle = SmartArtQuickStyleType.Polished;
            // smartArt.ColorStyle = SmartArtColorType.TransparentGradientRangeAccent1;

            // Retrieve the SmartArt shape (the last shape added to the slide)
            SmartArt smartArtShape = (SmartArt)slide.Shapes[slide.Shapes.Count - 1];

            // Render the SmartArt to an image
            IImage smartArtImage = smartArtShape.GetImage();

            // Define output path
            string outputPath = "SmartArt.png";

            try
            {
                // Save the image as PNG with transparent background
                smartArtImage.Save(outputPath, ImageFormat.Png);
            }
            catch (NotSupportedException)
            {
                // PNG format not supported for this operation
            }

            // Save the presentation (required before exit)
            try
            {
                presentation.Save("SmartArtPresentation.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // PPTX format not supported for this operation
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
