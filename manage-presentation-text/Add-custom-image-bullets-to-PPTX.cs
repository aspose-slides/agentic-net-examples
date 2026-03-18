using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Output directory
            string outDir = "Output";
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to hold the text
            float x = 50f;
            float y = 50f;
            float width = 400f;
            float height = 200f;
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, x, y, width, height);

            // Get the text frame of the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Remove the default paragraph
            int index = 0;
            textFrame.Paragraphs.RemoveAt(index);

            // Load an image file as bytes and add it to the presentation's image collection
            string imageFile = "bullet.png";
            byte[] imageBytes = File.ReadAllBytes(imageFile);
            Aspose.Slides.IPPImage ippImage = presentation.Images.AddImage(imageBytes);

            // Create a new paragraph with a picture bullet
            Aspose.Slides.Paragraph paragraph = new Aspose.Slides.Paragraph();
            paragraph.Text = "Welcome to Aspose.Slides!";
            paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Picture;
            paragraph.ParagraphFormat.Bullet.Picture.Image = ippImage;
            paragraph.ParagraphFormat.Bullet.Height = 12f; // Bullet height

            // Add the paragraph to the text frame
            textFrame.Paragraphs.Add(paragraph);

            // Save the presentation in PPTX and PPT formats
            string pptxPath = Path.Combine(outDir, "CustomBullet_out.pptx");
            string pptPath = Path.Combine(outDir, "CustomBullet_out.ppt");
            presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Save(pptPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}