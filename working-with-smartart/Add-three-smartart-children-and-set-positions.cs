using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];
        var smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.StackedList);

        // Parent node (first root node)
        var parentNode = smartArt.AllNodes[0];

        // Add first child node at position 0
        var child1 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(0);
        child1.TextFrame.Text = "Child 1";
        child1.Position = 0;

        // Add second child node at position 1
        var child2 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(1);
        child2.TextFrame.Text = "Child 2";
        child2.Position = 1;

        // Add third child node at position 2
        var child3 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(2);
        child3.TextFrame.Text = "Child 3";
        child3.Position = 2;

        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}