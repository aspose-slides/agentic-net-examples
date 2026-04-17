using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBackgroundUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string logoPath = "logo.png";
            string outputPath = "output.pptx";

            // Verify input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            // Verify logo image exists
            if (!File.Exists(logoPath))
            {
                Console.WriteLine("Logo image file not found: " + logoPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Load the logo image and add it to the presentation's image collection
                    IImage logoImage = Images.FromFile(logoPath);
                    IPPImage logoIppImage = pres.Images.AddImage(logoImage);

                    // Apply the logo as background image to each slide
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        slide.Background.Type = BackgroundType.OwnBackground;
                        slide.Background.FillFormat.FillType = FillType.Picture;
                        slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                        slide.Background.FillFormat.PictureFillFormat.Picture.Image = logoIppImage;
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}