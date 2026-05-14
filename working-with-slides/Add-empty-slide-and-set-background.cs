using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Path to the background image file
            string imagePath = "background.jpg";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation (contains one default empty slide)
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get a blank layout slide to use for the new empty slide
                    Aspose.Slides.ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

                    // Add a new empty slide to the end of the collection
                    Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(blankLayout);

                    // Add the background image to the presentation's image collection
                    Aspose.Slides.IPPImage backgroundImage = presentation.Images.AddImage(File.ReadAllBytes(imagePath));

                    // Configure the slide background to use the added image
                    newSlide.Background.Type = BackgroundType.OwnBackground;
                    newSlide.Background.FillFormat.FillType = FillType.Picture;
                    newSlide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                    newSlide.Background.FillFormat.PictureFillFormat.Picture.Image = backgroundImage;

                    // Save the presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided image format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}