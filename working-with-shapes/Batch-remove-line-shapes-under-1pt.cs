using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveThinLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported or file could not be opened
                Console.WriteLine("Failed to load presentation. The file format may not be supported.");
                return;
            }

            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate backwards to safely remove shapes
                for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Check if shape has a line format and its width is less than 1 point
                    if (shape.LineFormat != null && shape.LineFormat.Width < 1.0f)
                    {
                        slide.Shapes.Remove(shape);
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}