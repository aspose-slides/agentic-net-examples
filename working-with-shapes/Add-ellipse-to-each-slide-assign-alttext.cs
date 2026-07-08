using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchEllipse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (first argument) and output path (second argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    int shapeId = 1;

                    // Iterate through all slides and add an ellipse with sequential AltText
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Add an ellipse shape to the slide
                        Aspose.Slides.IAutoShape ellipse = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                            Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 150);

                        // Assign sequential identifier as alternative text
                        ellipse.AlternativeText = shapeId.ToString();
                        shapeId++;
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}