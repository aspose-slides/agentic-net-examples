using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceRectangleFills
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Process only rectangle auto shapes
                        if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                        {
                            // Set solid fill type and color to blue
                            autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            autoShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("All rectangle fills have been replaced with solid blue color.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the file format is not supported, an exception will be thrown.
            }
        }
    }
}