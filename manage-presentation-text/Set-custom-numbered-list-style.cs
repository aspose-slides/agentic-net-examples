// -----------------------------------------------------------------------------
// Example: Set custom numbered list style using C#
//
// Description:
// Demonstrates how to set custom numbered list style using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a shape 
// with a text frame, and applies different numbered bullet styles and start 
// numbers to paragraphs. It then saves the presentation as a PPTX file. 
// Developers can use this pattern to automate PPTX workflows, validate results, 
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom, Numbered, List, Style, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting custom numbered list styles.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to hold the text
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
            Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

            // Remove the default empty paragraph
            textFrame.Paragraphs.RemoveAt(0);

            // First paragraph with custom numbered bullet style and start number
            Aspose.Slides.Paragraph paragraph1 = new Aspose.Slides.Paragraph();
            paragraph1.Text = "First item";
            paragraph1.ParagraphFormat.Depth = 0;
            paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            paragraph1.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletArabicPeriod;
            paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)5;
            textFrame.Paragraphs.Add(paragraph1);

            // Second paragraph with a different bullet style
            Aspose.Slides.Paragraph paragraph2 = new Aspose.Slides.Paragraph();
            paragraph2.Text = "Second item";
            paragraph2.ParagraphFormat.Depth = 0;
            paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            paragraph2.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletAlphaUCPeriod;
            paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)1;
            textFrame.Paragraphs.Add(paragraph2);

            // Third paragraph with another bullet style
            Aspose.Slides.Paragraph paragraph3 = new Aspose.Slides.Paragraph();
            paragraph3.Text = "Third item";
            paragraph3.ParagraphFormat.Depth = 0;
            paragraph3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            paragraph3.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletRomanLCParenRight;
            paragraph3.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)10;
            textFrame.Paragraphs.Add(paragraph3);

            // Save the presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomNumberedList.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
