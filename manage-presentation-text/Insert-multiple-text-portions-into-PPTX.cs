using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertParagraphsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to hold text
                IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
                shape.AddTextFrame(string.Empty);

                // First paragraph with two portions
                IParagraph paragraph1 = new Paragraph();
                shape.TextFrame.Paragraphs.Add(paragraph1);

                IPortion portion1a = new Portion("Hello, ");
                paragraph1.Portions.Add(portion1a);

                IPortion portion1b = new Portion("World!");
                paragraph1.Portions.Add(portion1b);

                // Second paragraph with three portions
                IParagraph paragraph2 = new Paragraph();
                shape.TextFrame.Paragraphs.Add(paragraph2);

                IPortion portion2a = new Portion("This ");
                paragraph2.Portions.Add(portion2a);

                IPortion portion2b = new Portion("is ");
                paragraph2.Portions.Add(portion2b);

                IPortion portion2c = new Portion("a test.");
                paragraph2.Portions.Add(portion2c);

                // Save the presentation
                presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}