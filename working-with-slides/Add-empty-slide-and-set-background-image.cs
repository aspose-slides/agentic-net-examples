using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBackgroundExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "Output.pptx");
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "background.jpg");

            // Verify that the background image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Background image file not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Add an empty slide using the layout of the first slide
                    Aspose.Slides.ISlide newSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

                    // Set the slide background to use an image
                    newSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    newSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;

                    // Add the image to the presentation's image collection
                    Aspose.Slides.IPPImage img = pres.Images.AddImage(Aspose.Slides.Images.FromFile(imagePath));

                    // Assign the image to the slide background and set fill mode
                    newSlide.Background.FillFormat.PictureFillFormat.Picture.Image = img;
                    newSlide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

                    // Save the presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}