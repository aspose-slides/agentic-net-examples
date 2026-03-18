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
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string bulletImagePath = Path.Combine(dataDir, "bullet.png");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Add the picture to the presentation's image collection
                byte[] bulletImageBytes = File.ReadAllBytes(bulletImagePath);
                Aspose.Slides.IPPImage bulletImage = presentation.Images.AddImage(bulletImageBytes);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                        // Process only shapes that contain a text frame
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            // Iterate through all paragraphs in the text frame
                            for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                            {
                                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                                // Set bullet type to picture and assign the picture
                                paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Picture;
                                paragraph.ParagraphFormat.Bullet.Picture.Image = bulletImage;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}