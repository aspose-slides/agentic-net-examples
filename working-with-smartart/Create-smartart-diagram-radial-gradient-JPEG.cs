// -----------------------------------------------------------------------------
// Example: Create smartart diagram radial gradient JPEG using C#
//
// Description:
// Demonstrates how to create a SmartArt diagram with a radial gradient fill
// applied to each shape, save the presentation as PPTX, and export the slide
// as a JPEG image using Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, JPEG, Aspose.Slides for .NET, SmartArt, Radial Gradient,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of SmartArt diagrams with radial gradient fills.
// - Build C# tools for PowerPoint presentation processing and image export.
// - Generate or transform PPTX files with custom SmartArt styling in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtRadialGradientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outputDir = "output";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram (BasicBlockList layout)
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0, 0, 600, 400,
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Apply radial gradient fill to each shape of every SmartArt node
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
            {
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    // Set fill type to gradient
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

                    // Use radial gradient shape
                    shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Radial;

                    // Define gradient stops (purple to red)
                    shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
                    shape.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.Red);
                }
            }

            // Save the presentation (PPTX format)
            try
            {
                presentation.Save(Path.Combine(outputDir, "SmartArtRadial.pptx"), Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested save format is not supported.
            }

            // Export the slide as JPEG
            float scaleX = 1f;
            float scaleY = 1f;
            using (Aspose.Slides.IImage slideImage = slide.GetImage(scaleX, scaleY))
            {
                slideImage.Save(Path.Combine(outputDir, "Slide.jpg"), Aspose.Slides.ImageFormat.Jpeg);
            }

            // Save presentation before exit (already saved above)
            presentation.Dispose();
        }
    }
}
