using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyMultilevelBullets
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to hold the text
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);

                // Get the text frame of the shape
                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                // Clear any default paragraphs
                textFrame.Paragraphs.Clear();

                // First level bullet
                Aspose.Slides.Paragraph paragraph1 = new Aspose.Slides.Paragraph();
                paragraph1.Text = "First level bullet";
                paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
                paragraph1.ParagraphFormat.Depth = 0;
                textFrame.Paragraphs.Add(paragraph1);

                // Second level bullet
                Aspose.Slides.Paragraph paragraph2 = new Aspose.Slides.Paragraph();
                paragraph2.Text = "Second level bullet";
                paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
                paragraph2.ParagraphFormat.Depth = 1;
                textFrame.Paragraphs.Add(paragraph2);

                // Third level bullet
                Aspose.Slides.Paragraph paragraph3 = new Aspose.Slides.Paragraph();
                paragraph3.Text = "Third level bullet";
                paragraph3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
                paragraph3.ParagraphFormat.Depth = 2;
                textFrame.Paragraphs.Add(paragraph3);

                // Ensure output directory exists
                string outDir = "Output";
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Save the presentation as PPTX
                string outPath = Path.Combine(outDir, "MultilevelBullets_out.pptx");
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}