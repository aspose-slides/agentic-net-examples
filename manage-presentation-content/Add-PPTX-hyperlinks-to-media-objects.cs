using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddMediaHyperlink
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Load image bytes from file
                    byte[] imageBytes = File.ReadAllBytes("image.png");
                    // Add image to the presentation's image collection
                    Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

                    // Add a picture frame containing the image to the first slide
                    Aspose.Slides.IShape shape = presentation.Slides[0].Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        10, 10, 200, 150,
                        image);
                    Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;

                    // Assign a hyperlink to the picture frame
                    pictureFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.aspose.com/");
                    pictureFrame.HyperlinkClick.Tooltip = "Visit Aspose";

                    // Save the presentation
                    presentation.Save("MediaHyperlinkPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}