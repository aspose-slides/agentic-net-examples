using System;
using System.IO;
using Aspose.Slides.Export;

namespace AddBulletsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file name
            string outDir = "Output";
            string pptxFile = "BulletedPresentation.pptx";

            // Ensure output directory exists
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Create a new presentation
                presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to hold the text
                float shapeX = 50f;
                float shapeY = 50f;
                float shapeWidth = 500f;
                float shapeHeight = 300f;
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    shapeX,
                    shapeY,
                    shapeWidth,
                    shapeHeight);

                // Add a text frame to the shape
                Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(string.Empty);

                // Remove the default empty paragraph
                if (textFrame.Paragraphs.Count > 0)
                    textFrame.Paragraphs.RemoveAt(0);

                // Define bullet character (e.g., a solid circle)
                char bulletChar = '\u2022';

                // First bullet paragraph
                Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
                para1.Text = "First bullet point";
                para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(bulletChar);
                textFrame.Paragraphs.Add(para1);

                // Second bullet paragraph
                Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
                para2.Text = "Second bullet point";
                para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                para2.ParagraphFormat.Bullet.Char = System.Convert.ToChar(bulletChar);
                textFrame.Paragraphs.Add(para2);

                // Third bullet paragraph
                Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
                para3.Text = "Third bullet point";
                para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                para3.ParagraphFormat.Bullet.Char = System.Convert.ToChar(bulletChar);
                textFrame.Paragraphs.Add(para3);

                // Save the presentation
                string outPath = Path.Combine(outDir, pptxFile);
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                    presentation.Dispose();
            }
        }
    }
}