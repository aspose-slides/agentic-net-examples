using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode node = chevron.AllNodes.AddNode();
        node.TextFrame.Text = "Pattern Node";

        // Apply pattern fill to each shape of the node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
            shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
            shape.FillFormat.PatternFormat.ForeColor.Color = Color.Blue;
            shape.FillFormat.PatternFormat.BackColor.Color = Color.Yellow;
        }

        // Save the presentation
        string outputPath = "SmartArtPatternNode.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}