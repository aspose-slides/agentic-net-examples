// -----------------------------------------------------------------------------
// Example: Apply bullet formatting to paragraph with symbol using C#
//
// Description:
// Demonstrates how to create a new presentation, add a rectangle auto shape,
// insert a paragraph into its text frame, and apply a symbol bullet (solid
// bullet character) to that paragraph using Aspose.Slides for .NET. The example
// saves the resulting PPTX file, illustrating the steps required for bullet
// formatting in PowerPoint automation.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Apply Bullet, Symbol Bullet, Paragraph,
// Text Frame, Presentation Automation, Office Automation
//
// Use Cases:
// - Automate adding symbol bullets to paragraphs in generated presentations.
// - Build .NET tools that format text with custom bullet symbols.
// - Generate or modify PPTX files programmatically with specific bullet styles.
// - Validate bullet formatting in presentation workflows before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Get the text frame of the shape
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Remove the default paragraph if it exists
        if (textFrame.Paragraphs.Count > 0)
        {
            textFrame.Paragraphs.RemoveAt(0);
        }

        // Create a new paragraph
        Aspose.Slides.Paragraph paragraph = new Aspose.Slides.Paragraph();
        paragraph.Text = "Bullet Symbol Paragraph";

        // Set bullet type to Symbol
        paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;

        // Optionally set a bullet character (e.g., a solid bullet)
        paragraph.ParagraphFormat.Bullet.Char = System.Convert.ToChar(0x2022);

        // Add the paragraph to the text frame
        textFrame.Paragraphs.Add(paragraph);

        // Save the presentation
        try
        {
            presentation.Save("BulletSymbol.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        finally
        {
            presentation.Dispose();
        }
    }
}
