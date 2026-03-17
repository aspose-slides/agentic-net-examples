using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace CustomFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape with a text frame
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                ITextFrame textFrame = shape.AddTextFrame("Hello Custom Font World");

                // Define the custom font format for the target text segment
                PortionFormat format = new PortionFormat();
                format.LatinFont = new FontData("Comic Sans MS");
                format.FontHeight = 24f;

                // Apply the custom font to the specific text "Custom Font"
                SlideUtil.FindAndReplaceText(presentation, true, "Custom Font", "Custom Font", format);

                // Save the presentation
                presentation.Save("CustomFontPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}