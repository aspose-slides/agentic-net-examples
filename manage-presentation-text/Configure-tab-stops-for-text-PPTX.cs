using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to the slide
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                // Cast to IAutoShape to work with text
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

                // Add a text frame with tab-separated text
                autoShape.AddTextFrame("First\tSecond\tThird");

                // Get the first paragraph of the text frame
                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

                // Configure tab stops: position in points and alignment
                paragraph.ParagraphFormat.Tabs.Add(100.0, Aspose.Slides.TabAlignment.Left);
                paragraph.ParagraphFormat.Tabs.Add(200.0, Aspose.Slides.TabAlignment.Center);
                paragraph.ParagraphFormat.Tabs.Add(300.0, Aspose.Slides.TabAlignment.Right);

                // Save the presentation
                presentation.Save("ConfigureTabStops_out.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}