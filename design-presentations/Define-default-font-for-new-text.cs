using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Add a textbox shape with sample text
                var slide = presentation.Slides[0];
                var textbox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                textbox.AddTextFrame("Sample text with default font.");

                // Set default regular font for saving (used when source font is not found)
                var saveOptions = new PptxOptions();
                saveOptions.DefaultRegularFont = "Arial";

                // Save the presentation with the specified default font
                presentation.Save("DefaultFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}