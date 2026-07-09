using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneEllipses
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = "Data";
            string inputFile = Path.Combine(dataDir, "input.pptx");
            string outputFile = Path.Combine(dataDir, "output.pptx");

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputFile))
                {
                    foreach (ISlide slide in pres.Slides)
                    {
                        IShapeCollection shapes = slide.Shapes;
                        List<IShape> ellipses = new List<IShape>();

                        foreach (IShape shape in shapes)
                        {
                            if (shape is IAutoShape autoShape && autoShape.ShapeType == ShapeType.Ellipse)
                            {
                                ellipses.Add(shape);
                            }
                        }

                        foreach (IShape ellipse in ellipses)
                        {
                            float newX = ellipse.X + 20f;
                            float newY = ellipse.Y + 20f;
                            shapes.AddClone(ellipse, newX, newY);
                        }
                    }

                    pres.Save(outputFile, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // If the file format is not supported, handle accordingly
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}