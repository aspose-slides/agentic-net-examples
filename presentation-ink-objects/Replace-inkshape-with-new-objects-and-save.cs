using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceInkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;

                        if (inkShape != null)
                        {
                            // Remove the existing ink shape
                            slide.Shapes.RemoveAt(shapeIndex);

                            // Add a new placeholder rectangle at the same position and size
                            Aspose.Slides.IShape newShape = slide.Shapes.AddAutoShape(
                                Aspose.Slides.ShapeType.Rectangle,
                                inkShape.X,
                                inkShape.Y,
                                inkShape.Width,
                                inkShape.Height);
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // If the file format is not supported, handle accordingly
                // format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}