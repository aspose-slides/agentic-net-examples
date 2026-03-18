using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertTextRunExample
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

                // Add a rectangle AutoShape
                IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);

                // Add a TextFrame to the shape
                ITextFrame textFrame = autoShape.AddTextFrame("Initial text.");

                // Get the first paragraph
                IParagraph paragraph = textFrame.Paragraphs[0];

                // Create a new Portion (text run)
                Portion newPortion = new Portion("Inserted run");

                // Apply character formatting
                newPortion.PortionFormat.FontHeight = 24f;
                newPortion.PortionFormat.FontBold = NullableBool.True;
                newPortion.PortionFormat.LatinFont = new FontData("Arial");

                // Insert the new portion into the paragraph
                paragraph.Portions.Add(newPortion);

                // Save the presentation
                presentation.Save("InsertedRun.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}