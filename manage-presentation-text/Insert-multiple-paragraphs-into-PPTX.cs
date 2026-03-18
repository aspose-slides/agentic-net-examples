using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                var slide = presentation.Slides[0];

                // Add a rectangle shape to hold text
                var shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

                // Add an empty text frame
                shape.AddTextFrame(string.Empty);
                var textFrame = shape.TextFrame;

                // First paragraph with two portions
                var paragraph1 = new Aspose.Slides.Paragraph();
                var portion1a = new Aspose.Slides.Portion();
                portion1a.Text = "Hello, ";
                var portion1b = new Aspose.Slides.Portion();
                portion1b.Text = "World!";
                paragraph1.Portions.Add(portion1a);
                paragraph1.Portions.Add(portion1b);
                textFrame.Paragraphs.Add(paragraph1);

                // Second paragraph with two portions
                var paragraph2 = new Aspose.Slides.Paragraph();
                var portion2a = new Aspose.Slides.Portion();
                portion2a.Text = "Aspose ";
                var portion2b = new Aspose.Slides.Portion();
                portion2b.Text = "Slides";
                paragraph2.Portions.Add(portion2a);
                paragraph2.Portions.Add(portion2b);
                textFrame.Paragraphs.Add(paragraph2);

                // Save the presentation as PPTX
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}