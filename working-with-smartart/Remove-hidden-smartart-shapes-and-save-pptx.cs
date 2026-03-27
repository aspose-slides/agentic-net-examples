using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHiddenSmartArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Validate arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: RemoveHiddenSmartArt <input-pptx> <output-pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file does not exist: {inputPath}");
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through all slides
            foreach (ISlide slide in presentation.Slides)
            {
                // Iterate backwards to safely remove shapes
                for (int i = slide.Shapes.Count - 1; i >= 0; i--)
                {
                    IShape shape = slide.Shapes[i];
                    // Identify SmartArt shapes that are hidden
                    if (shape is Aspose.Slides.SmartArt.ISmartArt && shape.Hidden)
                    {
                        // Remove the hidden SmartArt shape
                        slide.Shapes.Remove(shape);
                    }
                }
            }

            // Save the cleaned presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}