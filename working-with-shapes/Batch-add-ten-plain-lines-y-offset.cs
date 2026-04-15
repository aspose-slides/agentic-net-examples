using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchLineAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input and output file paths
            string inputPath = args.Length > 0 ? args[0] : null;
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Load existing presentation or create a new one
            Aspose.Slides.Presentation pres;
            try
            {
                if (!string.IsNullOrEmpty(inputPath))
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine("Input file does not exist: " + inputPath);
                        return;
                    }
                    pres = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    pres = new Aspose.Slides.Presentation();
                }
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Add ten plain line shapes to each slide with incremental Y offset
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                for (int lineIndex = 0; lineIndex < 10; lineIndex++)
                {
                    float x = 50f;
                    float y = 50f + lineIndex * 20f; // Incremental Y offset
                    float width = 300f;
                    float height = 0f; // Height zero for a straight line

                    // Add a line shape (plain line without arrows)
                    Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Line, x, y, width, height);

                    // Optional: set line thickness
                    lineShape.LineFormat.Width = 2f;
                }
            }

            // Save the presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                pres.Dispose();
            }
        }
    }
}