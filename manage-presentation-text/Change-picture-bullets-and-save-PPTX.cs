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
            try
            {
                // Define output directory and ensure it exists
                string outDir = "Output";
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Path to the picture that will be used as a bullet
                string imagePath = "bullet.png";

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to hold text
                IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);

                // Get the text frame of the shape
                ITextFrame textFrame = autoShape.TextFrame;

                // Remove the default paragraph (if any)
                if (textFrame.Paragraphs.Count > 0)
                {
                    textFrame.Paragraphs.RemoveAt(0);
                }

                // Load image bytes and add the image to the presentation's image collection
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                IPPImage bulletImage = presentation.Images.AddImage(imageBytes);

                // Create a new paragraph with picture bullet
                Paragraph paragraph = new Paragraph();
                paragraph.Text = "Welcome to Aspose.Slides!";

                // Set bullet type to picture
                paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;

                // Assign the picture to the bullet
                paragraph.ParagraphFormat.Bullet.Picture.Image = bulletImage;

                // Set bullet height (in points)
                paragraph.ParagraphFormat.Bullet.Height = 12f;

                // Add the paragraph to the text frame
                textFrame.Paragraphs.Add(paragraph);

                // Save the presentation as PPTX
                string outputPath = Path.Combine(outDir, "PictureBulletPresentation.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}