using System;
using System.IO;
using Aspose.Slides.Export;

namespace AdjustValueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check command‑line arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: AdjustValueDemo <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Adjust the first shape's corner size (if present)
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes[0];
            for (int i = 0; i < shape.Adjustments.Count; i++)
            {
                if (shape.Adjustments.Count > 0 && shape.Adjustments[0].Type == Aspose.Slides.ShapeAdjustmentType.CornerSize)
                {
                    shape.Adjustments[0].AngleValue *= 2;
                }
            }

            // Adjust the second shape's arrow tail thickness and arrowhead length (if present)
            Aspose.Slides.IAutoShape shape1 = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes[1];
            for (int j = 0; j < shape1.Adjustments.Count; j++)
            {
                if (shape1.Adjustments.Count > 0 && shape1.Adjustments[0].Type == Aspose.Slides.ShapeAdjustmentType.ArrowTailThickness)
                {
                    shape1.Adjustments[0].AngleValue /= 3;
                }
                if (shape1.Adjustments.Count > 1 && shape1.Adjustments[1].Type == Aspose.Slides.ShapeAdjustmentType.ArrowheadLength)
                {
                    shape1.Adjustments[1].AngleValue /= 2;
                }
            }

            // Add a mathematical shape and manipulate its size and position using arithmetic operators
            Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
            // Increase width by 20%
            mathShape.Width = mathShape.Width * 1.2f;
            // Move shape down by 30 points
            mathShape.Y = mathShape.Y + 30f;

            // Save the modified presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                pres.Dispose();
            }
        }
    }
}