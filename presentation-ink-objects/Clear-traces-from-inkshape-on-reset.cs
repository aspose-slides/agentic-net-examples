using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (Aspose.Slides.IBaseSlide slide in presentation.Slides)
                {
                    // Collect Ink shapes to remove
                    System.Collections.Generic.List<Aspose.Slides.IShape> inkShapes = new System.Collections.Generic.List<Aspose.Slides.IShape>();
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                        if (inkShape != null)
                        {
                            inkShapes.Add(shape);
                        }
                    }

                    // Remove collected Ink shapes
                    foreach (Aspose.Slides.IShape shapeToRemove in inkShapes)
                    {
                        slide.Shapes.Remove(shapeToRemove);
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}