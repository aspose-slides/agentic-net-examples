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
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a rectangle shape with a text frame
                IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                    ShapeType.Rectangle, 50, 50, 400, 100);

                // Add first paragraph with Spanish language portion
                shape.AddTextFrame("Hola");
                IParagraph firstParagraph = shape.TextFrame.Paragraphs[0];
                IPortion firstPortion = firstParagraph.Portions[0];
                firstPortion.Text = "Hola";
                firstPortion.PortionFormat.LanguageId = "es-ES";

                // Add second paragraph with English language portion
                IParagraph secondParagraph = new Paragraph();
                IPortion secondPortion = new Portion("Hello");
                secondParagraph.Portions.Add(secondPortion);
                shape.TextFrame.Paragraphs.Add(secondParagraph);
                secondPortion.PortionFormat.LanguageId = "en-US";

                // Save the presentation
                string outputPath = "OutputPresentation.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}