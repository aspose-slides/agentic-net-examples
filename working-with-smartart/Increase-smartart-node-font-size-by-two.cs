using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a SmartArt diagram to the first slide
        ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

        // Iterate over all SmartArt nodes and increase font size by 2 points
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            if (node.TextFrame != null && node.TextFrame.Paragraphs.Count > 0)
            {
                foreach (IParagraph paragraph in node.TextFrame.Paragraphs)
                {
                    foreach (IPortion portion in paragraph.Portions)
                    {
                        portion.PortionFormat.FontHeight += 2;
                    }
                }
            }
        }

        // Save the presentation
        presentation.Save("SmartArtFontIncrease.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}