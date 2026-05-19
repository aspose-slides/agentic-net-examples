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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Set slide background to transparent (no fill)
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0f,               // X position
                0f,               // Y position
                400f,             // Width
                400f,             // Height
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Optionally customize the SmartArt (quick style, color, etc.)
            // smartArt.QuickStyle = Aspose.Slides.SmartArt.SmartArtQuickStyleType.Polished;
            // smartArt.ColorStyle = Aspose.Slides.SmartArt.SmartArtColorType.TransparentGradientRangeAccent1;

            // Retrieve the SmartArt shape (the last shape added to the slide)
            Aspose.Slides.SmartArt.SmartArt smartArtShape = (Aspose.Slides.SmartArt.SmartArt)slide.Shapes[slide.Shapes.Count - 1];

            // Render the SmartArt to an image
            Aspose.Slides.IImage smartArtImage = smartArtShape.GetImage();

            // Define output path
            string outputPath = "SmartArt.png";

            try
            {
                // Save the image as PNG with transparent background
                smartArtImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: PNG format not supported for this operation
            }

            // Save the presentation (required before exit)
            try
            {
                presentation.Save("SmartArtPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: PPTX format not supported for this operation
            }

            // Clean up
            presentation.Dispose();
        }
    }
}