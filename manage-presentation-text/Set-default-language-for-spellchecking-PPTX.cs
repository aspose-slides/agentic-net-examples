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
                // Create load options and set default text language
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.DefaultTextLanguage = "en-US";

                // Create a new presentation with the specified load options
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions))
                {
                    // Add a rectangle shape with a text frame
                    Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 100);
                    shape.AddTextFrame("Sample text with default language.");

                    // Enable spell checking for the added text portion
                    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.SpellCheck = true;

                    // Save the presentation
                    presentation.Save("DefaultLanguagePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}