using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetImageBackgrounds
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Directory containing the image files
                string dataDir = @"C:\Images\";

                // List of image file names to be used as backgrounds
                string[] imageFiles = new string[] { "image1.jpg", "image2.png", "image3.bmp" };

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Ensure there is at least one slide to obtain a layout slide reference
                    ISlide referenceSlide = pres.Slides[0];

                    // Iterate over each image file and set it as a slide background
                    foreach (string imageFile in imageFiles)
                    {
                        // Load image bytes from file
                        byte[] imgBytes = File.ReadAllBytes(Path.Combine(dataDir, imageFile));

                        // Add image to the presentation's image collection
                        IPPImage img = pres.Images.AddImage(imgBytes);

                        // Add a new empty slide based on the reference slide's layout
                        ISlide newSlide = pres.Slides.AddEmptySlide(referenceSlide.LayoutSlide);

                        // Set the background type to own background
                        newSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

                        // Configure the fill format to use the picture
                        newSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                        newSlide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                        newSlide.Background.FillFormat.PictureFillFormat.Picture.Image = img;
                    }

                    // Save the presentation to disk
                    pres.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}