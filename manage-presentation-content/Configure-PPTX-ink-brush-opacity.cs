using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using System.Drawing;

namespace ConfigureInkBrush
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output file paths
                string dataDir = "Data";
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                string inputPath = Path.Combine(dataDir, "input.pptx");
                string outputPath = Path.Combine(dataDir, "output.pptx");

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Assume the first shape is an Ink object
                Aspose.Slides.Ink.IInk ink = slide.Shapes[0] as Aspose.Slides.Ink.IInk;
                if (ink != null && ink.Traces.Length > 0)
                {
                    // Get the first trace's brush
                    Aspose.Slides.Ink.IInkBrush brush = ink.Traces[0].Brush;

                    // Set brush color (e.g., semi‑transparent blue)
                    brush.Color = Color.FromArgb(128, 0, 0, 255); // Alpha 128 for 50% opacity

                    // Set brush size (width and height in points)
                    brush.Size = new SizeF(10f, 10f);
                }

                // Configure rendering options to interpret mask operations as opacity
                Aspose.Slides.Export.RenderingOptions renderingOpts = new Aspose.Slides.Export.RenderingOptions();
                renderingOpts.InkOptions.InterpretMaskOpAsOpacity = true;

                // (Optional) Generate a thumbnail using the rendering options
                // slide.GetThumbnail(renderingOpts).Save(Path.Combine(dataDir, "thumb.png"), Aspose.Slides.ImageFormat.Png);

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}