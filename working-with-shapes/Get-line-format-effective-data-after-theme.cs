using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "example.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Ensure there is at least one slide and one shape
                    if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
                    {
                        Console.WriteLine("Presentation does not contain any slides or shapes.");
                        return;
                    }

                    // Get the first shape on the first slide
                    Aspose.Slides.IShape shape = presentation.Slides[0].Shapes[0];

                    // Retrieve effective line formatting after theme overrides
                    Aspose.Slides.ILineFormatEffectiveData effectiveLineFormat = shape.LineFormat.GetEffective();

                    // Output some effective line format properties
                    Console.WriteLine("Style: " + effectiveLineFormat.Style);
                    Console.WriteLine("Width: " + effectiveLineFormat.Width);
                    Console.WriteLine("Fill type: " + effectiveLineFormat.FillFormat.FillType);

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}