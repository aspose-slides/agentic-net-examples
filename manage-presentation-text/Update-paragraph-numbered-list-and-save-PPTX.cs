using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Output directory and file
            string outDir = "Output";
            System.IO.Directory.CreateDirectory(outDir);
            string outputPath = System.IO.Path.Combine(outDir, "UpdatedNumberedList.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 150, 400, 200);

            // Get the text frame of the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Remove the default empty paragraph
            textFrame.Paragraphs.RemoveAt(0);

            // First custom numbered paragraph
            Aspose.Slides.Paragraph paragraph1 = new Aspose.Slides.Paragraph();
            paragraph1.Text = "First item";
            paragraph1.ParagraphFormat.Depth = 0;
            paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
            textFrame.Paragraphs.Add(paragraph1);

            // Second custom numbered paragraph
            Aspose.Slides.Paragraph paragraph2 = new Aspose.Slides.Paragraph();
            paragraph2.Text = "Second item";
            paragraph2.ParagraphFormat.Depth = 0;
            paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
            textFrame.Paragraphs.Add(paragraph2);

            // Save the presentation as PPTX
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}