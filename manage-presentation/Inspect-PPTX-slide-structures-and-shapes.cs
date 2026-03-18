using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InspectPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output paths
                string dataDir = "Data";
                string inputPath = Path.Combine(dataDir, "input.pptx");
                string outputPath = Path.Combine(dataDir, "output_inspected.pptx");

                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through each slide
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    Console.WriteLine($"Slide {slideIndex + 1} (ID: {slide.SlideId})");

                    // Iterate through each shape on the slide
                    IShapeCollection shapes = slide.Shapes;
                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        IShape shape = shapes[shapeIndex];
                        string shapeInfo = $"  Shape {shapeIndex + 1}: Name=\"{shape.Name}\", RuntimeType=\"{shape.GetType().Name}\"";

                        // If the shape has a placeholder, include its type
                        if (shape.Placeholder != null)
                        {
                            shapeInfo += $", PlaceholderType={shape.Placeholder.Type}";
                        }

                        Console.WriteLine(shapeInfo);
                    }
                }

                // Save the (unchanged) presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}