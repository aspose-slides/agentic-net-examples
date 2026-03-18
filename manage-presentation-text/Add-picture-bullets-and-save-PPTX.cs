using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PictureBulletExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file names
            string outDir = "Output";
            string pptxFile = "output.pptx";
            string pptFile = "output.ppt";
            string imageFile = "bullet.png";

            try
            {
                // Ensure output directory exists
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to hold the text
                IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    ShapeType.Rectangle, 50, 50, 400, 100);

                // Get the text frame of the shape
                ITextFrame textFrame = autoShape.TextFrame;

                // Remove the default paragraph (if any)
                if (textFrame.Paragraphs.Count > 0)
                {
                    textFrame.Paragraphs.RemoveAt(0);
                }

                // Load the bullet image from file and add it to the presentation's image collection
                byte[] imageBytes = File.ReadAllBytes(imageFile);
                IPPImage ippImage = presentation.Images.AddImage(imageBytes);

                // Create a new paragraph with picture bullet
                Paragraph paragraph = new Paragraph();
                paragraph.Text = "Welcome to Aspose.Slides!";
                paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
                paragraph.ParagraphFormat.Bullet.Picture.Image = ippImage;
                paragraph.ParagraphFormat.Bullet.Height = 12;

                // Add the paragraph to the text frame
                textFrame.Paragraphs.Add(paragraph);

                // Save the presentation in PPTX and PPT formats
                presentation.Save(Path.Combine(outDir, pptxFile), SaveFormat.Pptx);
                presentation.Save(Path.Combine(outDir, pptFile), SaveFormat.Ppt);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}