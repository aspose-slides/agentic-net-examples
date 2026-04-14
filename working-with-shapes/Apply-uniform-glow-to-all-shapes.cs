using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

class Program
{
    static void Main(string[] args)
    {
        // List of presentation files to process
        string[] presentationFiles = new string[] { "input1.pptx", "input2.pptx" };
        // Uniform glow radius to apply
        double glowRadius = 10.0;

        foreach (string filePath in presentationFiles)
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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);

                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Iterate through all shapes on the slide
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[j];

                        // Enable glow effect for the shape
                        shape.EffectFormat.EnableGlowEffect();

                        // Set the glow radius if the effect is available
                        if (shape.EffectFormat.GlowEffect != null)
                        {
                            shape.EffectFormat.GlowEffect.Radius = glowRadius;
                        }
                    }
                }

                // Save the modified presentation (overwrites the original file)
                presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Processed and saved: " + filePath);
            }
            catch (Exception ex)
            {
                // Handle unsupported formats or other processing errors
                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
            }
        }
    }
}