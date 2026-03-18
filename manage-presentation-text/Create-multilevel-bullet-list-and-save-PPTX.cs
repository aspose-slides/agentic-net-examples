using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Define output directory and file name
                string outDir = "Output";
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }
                string outputPath = Path.Combine(outDir, "MultilevelBulletList.pptx");

                // Create a new presentation
                presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to host the text
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);

                // Add a text frame to the shape
                Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(string.Empty);

                // Remove the default empty paragraph
                textFrame.Paragraphs.RemoveAt(0);

                // Create first level paragraph
                Aspose.Slides.Paragraph paraLevel1 = new Aspose.Slides.Paragraph();
                paraLevel1.Text = "First level item";
                paraLevel1.ParagraphFormat.Depth = 0;
                paraLevel1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                paraLevel1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226); // •
                textFrame.Paragraphs.Add(paraLevel1);

                // Create second level paragraph
                Aspose.Slides.Paragraph paraLevel2 = new Aspose.Slides.Paragraph();
                paraLevel2.Text = "Second level item";
                paraLevel2.ParagraphFormat.Depth = 1;
                paraLevel2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                paraLevel2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
                textFrame.Paragraphs.Add(paraLevel2);

                // Create third level paragraph
                Aspose.Slides.Paragraph paraLevel3 = new Aspose.Slides.Paragraph();
                paraLevel3.Text = "Third level item";
                paraLevel3.ParagraphFormat.Depth = 2;
                paraLevel3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                paraLevel3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
                textFrame.Paragraphs.Add(paraLevel3);

                // Save the presentation in PPTX format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}