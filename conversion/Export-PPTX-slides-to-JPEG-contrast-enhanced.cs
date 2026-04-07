using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            using (Presentation presentation = new Presentation(inputPath))
            {
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];

                    foreach (IShape shape in slide.Shapes)
                    {
                        IPictureFrame pictureFrame = shape as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
                            // Increase brightness and contrast by 20%
                            imageTransform.AddBrightnessContrastEffect(0.2f, 0.2f);
                        }
                    }

                    IImage slideImage = slide.GetImage(1f, 1f);
                    string outputPath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");
                    slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the modified presentation
                string savedPath = Path.Combine(outputDir, "ModifiedPresentation.pptx");
                presentation.Save(savedPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}