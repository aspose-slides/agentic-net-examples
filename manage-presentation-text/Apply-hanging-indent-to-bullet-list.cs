// -----------------------------------------------------------------------------
// Example: Apply hanging indent to bullet list using C#
//
// Description:
// Demonstrates how to create a rectangle shape, add a text frame with bullet
// paragraphs, and apply a hanging indent by setting a negative paragraph
// indent using Aspose.Slides for .NET. The example saves the result as a PPTX
// file that can be opened in PowerPoint.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Hanging Indent, Bullet List, Text Frame,
// Paragraph Formatting, Presentation Automation, Office Automation
//
// Use Cases:
// - Programmatically apply hanging indent to bullet lists in presentations.
// - Generate PowerPoint slides with custom formatted bullet points.
// - Automate creation of PPTX files with specific text layout requirements.
// - Integrate bullet list formatting into .NET applications.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape rect = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
            // Add a text frame
            Aspose.Slides.ITextFrame textFrame = rect.AddTextFrame("Bullet List:");
            // Set autofit type
            textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;
            // Remove the default paragraph
            textFrame.Paragraphs.RemoveAt(0);
            // First bullet paragraph
            Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
            para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
            para1.Text = "First item";
            // Apply hanging indent of 10 points (negative indent value)
            para1.ParagraphFormat.Indent = -10f;
            textFrame.Paragraphs.Add(para1);
            // Second bullet paragraph
            Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
            para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para2.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
            para2.Text = "Second item";
            para2.ParagraphFormat.Indent = -10f;
            textFrame.Paragraphs.Add(para2);
            // Save the presentation
            string outputPath = "HangingIndentExample.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported
        }
    }
}
