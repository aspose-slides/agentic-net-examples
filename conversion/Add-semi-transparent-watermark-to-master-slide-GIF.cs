// -----------------------------------------------------------------------------
// Example: Add semi transparent watermark to master slide GIF using C#
//
// Description:
// Demonstrates how to add a semi‑transparent text watermark to the first master
// slide of a PowerPoint presentation and then export the presentation as an
// animated GIF using Aspose.Slides for .NET. The watermark is created as a
// rectangle shape with semi‑transparent fill, illustrating the required steps
// for presentation processing and GIF conversion in a standalone console
// application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Semi‑Transparent, Watermark,
// Master Slide, GIF Conversion, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a semi‑transparent watermark to the master slide before
//   generating GIF animations.
// - Build C# utilities for PowerPoint presentation processing and branding.
// - Generate animated GIFs from PPTX files with embedded watermarks.
// - Validate and test presentation workflows in .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace WatermarkGifExample
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Add a semi‑transparent logo watermark to the first master slide
                IMasterSlide master = pres.Masters[0];
                IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                    ShapeType.Rectangle, 100, 100, 200, 50);
                watermarkShape.AddTextFrame("Logo");
                watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;

                // Set semi‑transparent fill for the shape
                watermarkShape.FillFormat.FillType = FillType.Solid;
                watermarkShape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 255, 0, 0); // 50% transparent red
                watermarkShape.FillFormat.Transparency = 0.5f; // Additional transparency control

                // Remove outline
                watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;

                // Convert the presentation to an animated GIF
                try
                {
                    GifOptions gifOptions = new GifOptions
                    {
                        TransitionFps = 30 // Set desired FPS
                    };
                    pres.Save(outputPath, SaveFormat.Gif, gifOptions);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}
