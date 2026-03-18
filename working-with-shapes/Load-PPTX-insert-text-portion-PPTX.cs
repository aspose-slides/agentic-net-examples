using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Get the first slide (target slide)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to the slide
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    100f, 100f, 300f, 100f,
                    false);

                // Add an empty text frame to the shape
                Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("");

                // Get the first paragraph of the text frame
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

                // Insert a new text portion using the Portion constructor
                Aspose.Slides.Portion newPortion = new Aspose.Slides.Portion("Inserted text via AddPortion");
                paragraph.Portions.Add(newPortion);

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}