using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace ExportSlidesWithContrast
{
    class Program
    {
        static void Main()
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Apply automatic brightness/contrast enhancement to all picture frames on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is IPictureFrame)
                            {
                                IPictureFrame pictureFrame = (IPictureFrame)shape;
                                IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

                                // Add a brightness/contrast effect (values can be adjusted as needed)
                                imageTransform.AddBrightnessContrastEffect(0.2f, 0.2f);
                            }
                        }

                        // Export the slide to a JPEG image
                        IImage slideImage = slide.GetImage(1f, 1f);
                        string outputImagePath = $"slide_{slideIndex + 1}.jpg";
                        slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
                    }

                    // Save the modified presentation (if needed)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}