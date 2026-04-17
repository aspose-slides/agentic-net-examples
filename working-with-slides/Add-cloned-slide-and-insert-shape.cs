using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Clone the first slide to the end of the collection
                ISlideCollection slides = pres.Slides;
                ISlide clonedSlide = slides.AddClone(slides[0]);

                // Add a new rectangle shape to the cloned slide for additional information
                clonedSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (PptxEditException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}