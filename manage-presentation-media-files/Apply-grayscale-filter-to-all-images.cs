using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output_grayscale.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Process only picture frames
                    Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                    if (pictureFrame != null)
                    {
                        // Access the picture inside the frame
                        Aspose.Slides.ISlidesPicture slidesPicture = pictureFrame.PictureFormat.Picture;

                        // Apply grayscale effect to the picture's image transform collection
                        slidesPicture.ImageTransform.AddGrayScaleEffect();
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}