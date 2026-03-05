using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetTextTabulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 100);
            shape.AddTextFrame("Item1\tItem2\tItem3");

            // Get the first paragraph of the text frame
            Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];

            // Add a tab at position 100 points, left-aligned
            Aspose.Slides.ITabCollection tabs = paragraph.ParagraphFormat.Tabs;
            tabs.Add(new Aspose.Slides.Tab(100.0, Aspose.Slides.TabAlignment.Left));

            // Save the presentation
            presentation.Save("SetTab_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}