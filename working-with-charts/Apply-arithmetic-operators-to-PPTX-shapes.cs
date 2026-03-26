using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Adjust the first shape's CornerSize adjustment (if present)
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes[0];
        for (int i = 0; i < shape.Adjustments.Count; i++)
        {
            if (shape.Adjustments.Count > 0 && shape.Adjustments[0].Type == Aspose.Slides.ShapeAdjustmentType.CornerSize)
            {
                shape.Adjustments[0].AngleValue = shape.Adjustments[0].AngleValue * 2;
            }
        }

        // Adjust the second shape's ArrowTailThickness and ArrowheadLength adjustments (if present)
        Aspose.Slides.IAutoShape shape1 = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes[1];
        for (int j = 0; j < shape1.Adjustments.Count; j++)
        {
            if (shape1.Adjustments.Count > 0 && shape1.Adjustments[0].Type == Aspose.Slides.ShapeAdjustmentType.ArrowTailThickness)
            {
                shape1.Adjustments[0].AngleValue = shape1.Adjustments[0].AngleValue / 3;
            }
        }
        if (shape1.Adjustments.Count > 1 && shape1.Adjustments[1].Type == Aspose.Slides.ShapeAdjustmentType.ArrowheadLength)
        {
            shape1.Adjustments[1].AngleValue = shape1.Adjustments[1].AngleValue / 2;
        }

        // Add a new rectangle shape and perform arithmetic on its properties
        Aspose.Slides.IAutoShape rectShape = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
        // Increase width by 50%
        rectShape.Width = rectShape.Width * 1.5f;
        // Move shape down by 20 points
        rectShape.Y = rectShape.Y + 20;

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}