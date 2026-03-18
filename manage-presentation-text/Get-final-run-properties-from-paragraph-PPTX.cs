using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape with a text frame
                    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                    shape.AddTextFrame("First portion. ");

                    // Access the first paragraph
                    IParagraph paragraph = shape.TextFrame.Paragraphs[0];

                    // Add another portion (the final run) to the paragraph
                    IPortion finalPortion = new Portion("Final run");
                    paragraph.Portions.Add(finalPortion);

                    // Modify the final run's font height
                    finalPortion.PortionFormat.FontHeight = 24f;

                    // Retrieve the font height to demonstrate reading
                    float fontHeight = finalPortion.PortionFormat.FontHeight;
                    Console.WriteLine("Final run font height set to: " + fontHeight);

                    // Save the presentation
                    presentation.Save("ModifiedPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}