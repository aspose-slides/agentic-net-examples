using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LoadPptxAddEllipse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputPath = "input.pptx";
            string outputFolder = "Output";
            string outputPath = Path.Combine(outputFolder, "output.pptx");

            try
            {
                // Ensure the output directory exists
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                // Load the existing presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide (index 0)
                    ISlide slide = presentation.Slides[0];

                    // Add an ellipse shape to the slide
                    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 300, 150);

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}