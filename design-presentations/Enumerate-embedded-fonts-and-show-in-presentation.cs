using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Retrieve embedded fonts
            var embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            // Use the first slide (created by default)
            var slide = presentation.Slides[0];

            // Add a rectangle shape to hold the font list
            var textbox = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);
            textbox.AddTextFrame("Embedded Fonts:");

            // Get the text frame to add font names
            var textFrame = textbox.TextFrame;

            // Append each embedded font name as a new paragraph
            foreach (var font in embeddedFonts)
            {
                var paragraph = new Aspose.Slides.Paragraph();
                var portion = new Aspose.Slides.Portion(font.FontName);
                paragraph.Portions.Add(portion);
                textFrame.Paragraphs.Add(paragraph);
            }

            // Save the presentation
            presentation.Save("EmbeddedFonts.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}