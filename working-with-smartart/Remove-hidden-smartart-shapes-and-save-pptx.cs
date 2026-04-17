using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace RemoveHiddenSmartArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_cleaned.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through shapes in reverse order to safely remove them
                        for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Cast shape to SmartArt
                            SmartArt smartArt = shape as SmartArt;

                            // If it's a SmartArt shape and hidden, remove it
                            if (smartArt != null && smartArt.Hidden)
                            {
                                slide.Shapes.RemoveAt(shapeIndex);
                            }
                        }
                    }

                    // Save the cleaned presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}