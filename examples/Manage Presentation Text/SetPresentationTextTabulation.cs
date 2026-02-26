using System;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

            // Add a text frame and set its text
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("First\tSecond\tThird");

            // Access the first paragraph
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Add a tab at position 100 points with left alignment
            Aspose.Slides.ITabCollection tabs = paragraph.ParagraphFormat.Tabs;
            tabs.Add(new Aspose.Slides.Tab(100, Aspose.Slides.TabAlignment.Left));

            // Save the presentation
            presentation.Save("Tabulation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}