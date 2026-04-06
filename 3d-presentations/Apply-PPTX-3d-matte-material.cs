using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyMatteMaterial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Allow overriding input path via command line argument
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // If the input file does not exist, create a new presentation with a sample 3D shape
            if (!File.Exists(inputPath))
            {
                using (Presentation pres = new Presentation())
                {
                    // Add a rectangle shape and give it a 3D effect
                    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 200);
                    shape.ThreeDFormat.Depth = 5;
                    shape.ThreeDFormat.Material = MaterialPresetType.Matte;

                    // Save the newly created presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }

                return;
            }

            try
            {
                // Load the existing presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides and shapes
                    foreach (ISlide slide in pres.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Apply matte material to any shape that has a ThreeDFormat
                            if (shape.ThreeDFormat != null)
                            {
                                shape.ThreeDFormat.Material = MaterialPresetType.Matte;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
        }
    }
}