using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace SetPictureFillBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the image file that will be used as picture fill
            string imagePath = "background.jpg";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                try
                {
                    // Load image from a file stream and add it to the presentation's image collection
                    using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        // Keep the stream locked to avoid additional file access
                        IPPImage pictureImage = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);

                        // Configure the background of the first slide to use picture fill
                        ISlide slide = presentation.Slides[0];
                        slide.Background.Type = BackgroundType.OwnBackground;
                        slide.Background.FillFormat.FillType = FillType.Picture;
                        slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

                        // Assign the loaded image to the picture fill
                        slide.Background.FillFormat.PictureFillFormat.Picture.Image = pictureImage;

                        // Apply 30% transparency using AlphaModulateFixed effect
                        IImageTransformOperationCollection transformOps = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;
                        // Amount is a percentage (0.0f – 1.0f). 0.3f corresponds to 30% opacity (70% transparent)
                        transformOps.AddAlphaModulateFixedEffect(0.3f);
                    }

                    // Save the presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("The specified file format is not supported.");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., I/O errors, Aspose.Slides errors)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}