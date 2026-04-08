using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation pres = null;
            try
            {
                // Load the presentation
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle loading errors (e.g., unsupported format)
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // format not supported
                return;
            }

            // Mark all shapes as decorative to exclude them from screen reader output
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                for (int j = 0; j < slide.Shapes.Count; j++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[j];
                    shape.IsDecorative = true;
                }
            }

            try
            {
                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}