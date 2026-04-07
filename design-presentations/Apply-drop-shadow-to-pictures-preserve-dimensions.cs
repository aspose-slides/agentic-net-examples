using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyDropShadowToPictures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as command line arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ApplyDropShadowToPictures <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file does not exist: {inputPath}");
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine($"Failed to load presentation: {ex.Message}");
                // Format not supported comment
                // Format not supported.
                return;
            }

            // Iterate through all slides and apply preset drop shadow to picture shapes
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IPictureFrame pictureFrame)
                    {
                        // Preserve original dimensions (no changes to Width/Height)
                        // Enable a preset shadow effect
                        pictureFrame.EffectFormat.EnablePresetShadowEffect();
                    }
                }
            }

            try
            {
                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save presentation: {ex.Message}");
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}