using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        var node = smartArt.AllNodes.AddNode();
        node.TextFrame.Text = "Node with Gradient";

        foreach (ISmartArtShape shape in node.Shapes)
        {
            shape.FillFormat.FillType = FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
            shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner1;
            shape.FillFormat.GradientFormat.GradientStops.Add(0, PresetColor.Red);
            shape.FillFormat.GradientFormat.GradientStops.Add(0.5f, PresetColor.Purple);
            shape.FillFormat.GradientFormat.GradientStops.Add(1, PresetColor.Blue);
        }

        foreach (ISmartArtShape shape in node.Shapes)
        {
            if (shape.FillFormat.GradientFormat.GradientDirection == GradientDirection.FromCorner1)
            {
                Console.WriteLine("Gradient orientation is FromCorner1 as expected.");
            }
            else
            {
                Console.WriteLine("Gradient orientation differs.");
            }
        }

        var outPath = "GradientSmartArt.pptx";
        try
        {
            presentation.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        presentation.Dispose();
    }
}