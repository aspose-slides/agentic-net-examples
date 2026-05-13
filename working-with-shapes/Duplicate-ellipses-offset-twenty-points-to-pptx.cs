using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    foreach (ISlide slide in presentation.Slides)
                    {
                        List<IShape> ellipses = new List<IShape>();
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is IAutoShape)
                            {
                                IAutoShape autoShape = (IAutoShape)shape;
                                if (autoShape.ShapeType == ShapeType.Ellipse)
                                {
                                    ellipses.Add(shape);
                                }
                            }
                        }

                        foreach (IShape ellipse in ellipses)
                        {
                            IAutoShape original = (IAutoShape)ellipse;
                            float newX = original.X + 20f;
                            float newY = original.Y + 20f;
                            float width = original.Width;
                            float height = original.Height;
                            slide.Shapes.AddAutoShape(ShapeType.Ellipse, newX, newY, width, height);
                        }
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}