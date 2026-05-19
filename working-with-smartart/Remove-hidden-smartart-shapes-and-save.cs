using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHiddenSmartArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_cleaned.pptx";

            // Check if the input file exists
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
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
                // Handle unsupported format or loading errors
                // format not supported
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate backwards through shapes to allow removal
                for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is a SmartArt diagram
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                        // Remove the shape if it is hidden
                        if (smartArt.Hidden)
                        {
                            slide.Shapes.RemoveAt(shapeIndex);
                        }
                    }
                }
            }

            // Save the cleaned presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();

            Console.WriteLine("Hidden SmartArt shapes removed and saved to: " + outputPath);
        }
    }
}