using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchRemoveLineShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    foreach (ISlide slide in presentation.Slides)
                    {
                        List<IShape> shapesToRemove = new List<IShape>();
                        foreach (IShape shape in slide.Shapes)
                        {
                            AutoShape autoShape = shape as AutoShape;
                            if (autoShape != null &&
                                autoShape.ShapeType == ShapeType.Line &&
                                autoShape.Width < 1f)
                            {
                                shapesToRemove.Add(autoShape);
                            }
                        }

                        foreach (IShape shape in shapesToRemove)
                        {
                            slide.Shapes.Remove(shape);
                        }
                    }

                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
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