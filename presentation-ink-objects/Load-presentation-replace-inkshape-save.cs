using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace InkReplacementDemo
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through shapes in reverse order to allow removal
                        for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Identify Ink shapes
                            if (shape is Ink)
                            {
                                // Preserve original geometry for the replacement shape
                                float x = shape.X;
                                float y = shape.Y;
                                float width = shape.Width;
                                float height = shape.Height;

                                // Remove the existing Ink shape
                                slide.Shapes.RemoveAt(shapeIndex);

                                // Add a new line shape that simulates ink using a scribble sketch
                                IAutoShape newInkShape = (IAutoShape)slide.Shapes.AddAutoShape(
                                    ShapeType.Line, x, y, width, height);
                                newInkShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;
                            }
                        }
                    }

                    // Save the updated presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}