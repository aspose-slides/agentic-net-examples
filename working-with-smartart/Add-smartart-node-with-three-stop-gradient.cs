using Aspose.Slides.Export;
using System;

class Program
{
    static void Main()
    {
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
        node.TextFrame.Text = "Gradient Node";
        Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
        shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, Aspose.Slides.PresetColor.Purple);
        shape.FillFormat.GradientFormat.GradientStops.Add(0.5f, Aspose.Slides.PresetColor.Red);
        shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, Aspose.Slides.PresetColor.Yellow);
        bool isCorrectDirection = shape.FillFormat.GradientFormat.GradientDirection == Aspose.Slides.GradientDirection.FromCorner2;
        System.Console.WriteLine("Gradient direction is correct: " + isCorrectDirection);
        presentation.Save("SmartArtGradient.pptx", SaveFormat.Pptx);
        presentation.Dispose();
    }
}