using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // List of presentation files to process
        string[] inputFiles = new string[] { "input1.pptx", "input2.pptx" };

        foreach (string filePath in inputFiles)
        {
            // Verify that the file exists before attempting to load
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                continue;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(filePath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Apply a uniform glow effect to the shape
                            shape.EffectFormat.EnableGlowEffect();
                        }
                    }

                    // Save the modified presentation with a new name
                    string outputPath = Path.Combine(
                        Path.GetDirectoryName(filePath),
                        Path.GetFileNameWithoutExtension(filePath) + "_glow.pptx");

                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Unsupported format for file: " + filePath);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing file: " + filePath);
                Console.WriteLine(ex.Message);
            }
        }
    }
}