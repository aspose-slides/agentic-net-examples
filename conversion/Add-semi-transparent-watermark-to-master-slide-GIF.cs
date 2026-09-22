// -----------------------------------------------------------------------------
// Example: Add Semi-Transparent Watermark to Master Slide and Export as GIF
//
// Description:
// This console application loads a PowerPoint file, adds a semi‑transparent
// text watermark to the first master slide using Aspose.Slides for .NET, and
// exports the presentation as an animated GIF. It demonstrates handling of
// file existence, fill transparency via ARGB colors, and GIF conversion.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, watermark, semi-transparent, GIF export
//
// Use Cases:
// - Branding presentations with a confidential watermark before distribution.
// - Converting a watermarked slide deck into an animated GIF for web preview.
// - Automating slide master modifications in batch processing pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace WatermarkGifExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputGifPath = "output.gif";

            // Verify that the input PowerPoint file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found -> " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Access the first master slide
                Aspose.Slides.IMasterSlide master = pres.Masters[0];

                // Add a rectangle shape that will serve as the watermark
                Aspose.Slides.IAutoShape watermarkShape = (Aspose.Slides.IAutoShape)master.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    100,   // X position
                    100,   // Y position
                    400,   // Width
                    100    // Height
                );

                // Add text to the shape
                watermarkShape.AddTextFrame("CONFIDENTIAL");
                watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                // Set a semi‑transparent fill (alpha = 128 out of 255)
                watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                watermarkShape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.LightGray);

                // Remove the shape outline
                watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Prepare GIF export options (default options are sufficient for a basic example)
                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();

                // Export the presentation as an animated GIF
                pres.Save(outputGifPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

                Console.WriteLine("Watermarked GIF created successfully at: " + outputGifPath);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., unsupported format, library issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
