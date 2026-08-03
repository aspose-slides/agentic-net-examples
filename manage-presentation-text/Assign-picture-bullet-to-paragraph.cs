// -----------------------------------------------------------------------------
// Example: Assign picture bullet to paragraph using C#
//
// Description:
// Demonstrates how to assign a picture bullet to a paragraph using C# and 
// Aspose.Slides for .NET. The example loads or creates a presentation, adds a 
// picture to the presentation's image collection, creates a text shape if needed, 
// and sets the first paragraph's bullet type to a picture bullet using the 
// specified image. The resulting presentation is saved as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Assign, Picture, Bullet, 
// Paragraph, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate assigning picture bullets to paragraphs in PowerPoint slides.
// - Build C# tools for PowerPoint presentation processing that require custom bullet styles.
// - Generate or transform PPTX files with image-based bullets in .NET applications.
// - Validate presentation workflows involving picture bullets before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AssignPictureBullet
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string imagePath = "bullet.png";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Load existing presentation if it exists, otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to load presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                presentation = new Presentation();
            }

            // Add the picture to the presentation's image collection
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            IPPImage bulletImage = presentation.Images.AddImage(imageBytes);

            // Ensure there is at least one slide
            if (presentation.Slides.Count == 0)
            {
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a textbox shape if none exists
            IAutoShape textShape = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                {
                    textShape = autoShape;
                    break;
                }
            }
            if (textShape == null)
            {
                textShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                textShape.AddTextFrame("Sample paragraph with picture bullet.");
            }

            // Get the first paragraph
            IParagraph paragraph = textShape.TextFrame.Paragraphs[0];

            // Set bullet type to picture
            paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;

            // Assign the picture bullet image
            ISlidesPicture bulletPicture = paragraph.ParagraphFormat.Bullet.Picture;
            bulletPicture.Image = bulletImage;

            // Save the presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified save format is not supported.");
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}
