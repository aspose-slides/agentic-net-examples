using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Add first node and set its text
        Aspose.Slides.SmartArt.ISmartArtNode node1 = smartArt.AllNodes.AddNode();
        node1.TextFrame.Text = "Node 1";

        // Apply pattern fill to each shape in the first node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node1.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
            shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
            shape.FillFormat.PatternFormat.ForeColor.Color = Color.Blue;
            shape.FillFormat.PatternFormat.BackColor.Color = Color.Yellow;
        }

        // Add second node and set its text
        Aspose.Slides.SmartArt.ISmartArtNode node2 = smartArt.AllNodes.AddNode();
        node2.TextFrame.Text = "Node 2";

        // Apply pattern fill to each shape in the second node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node2.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
            shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.Horizontal;
            shape.FillFormat.PatternFormat.ForeColor.Color = Color.Green;
            shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
        }

        // Save the presentation as PDF with exception handling
        try
        {
            presentation.Save("SmartArtPattern.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception)
        {
            // Format not supported or other error
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}