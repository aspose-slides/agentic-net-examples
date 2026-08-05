// -----------------------------------------------------------------------------
// Example: Add ellipse circle pattern fill to jpeg using C#
//
// Description:
// Demonstrates how to add an ellipse shape with a small circles pattern fill
// to a PowerPoint slide and export the slide as a JPEG image using C# and 
// Aspose.Slides for .NET. The example shows the required presentation-processing 
// steps for creating a shape, applying a pattern fill, saving the presentation, 
// and rendering the slide to a JPEG file in a standalone console application. 
// Developers can use this pattern to automate PPTX workflows, validate results, 
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Ellipse, Circle, Pattern, 
// Fill, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding ellipse circle pattern fill to slides and exporting to JPEG.
// - Build C# tools for PowerPoint presentation processing with custom shape styling.
// - Generate or transform PPTX files and render them as images in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an ellipse shape
            IShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

            // Apply pattern fill (small circles)
            ellipse.FillFormat.FillType = FillType.Pattern;
            ellipse.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallConfetti; // small circles pattern
            ellipse.FillFormat.PatternFormat.BackColor.Color = System.Drawing.Color.White;
            ellipse.FillFormat.PatternFormat.ForeColor.Color = System.Drawing.Color.Black;

            // Save the presentation (handle unsupported format)
            string presentationPath = Path.Combine(outputDir, "EllipsePattern.pptx");
            try
            {
                presentation.Save(presentationPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Export the slide as JPEG
            float scaleX = 1f;
            float scaleY = 1f;
            using (IImage slideImage = slide.GetImage(scaleX, scaleY))
            {
                string jpegPath = Path.Combine(outputDir, "Slide1.jpg");
                slideImage.Save(jpegPath, ImageFormat.Jpeg);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
