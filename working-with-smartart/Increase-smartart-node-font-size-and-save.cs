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

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram
        ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

        // Iterate over all SmartArt nodes and increase font size by 2 points
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            if (node.TextFrame != null && node.TextFrame.Paragraphs != null)
            {
                foreach (IParagraph paragraph in node.TextFrame.Paragraphs)
                {
                    foreach (IPortion portion in paragraph.Portions)
                    {
                        float currentSize = portion.PortionFormat.FontHeight;
                        portion.PortionFormat.FontHeight = currentSize + 2;
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