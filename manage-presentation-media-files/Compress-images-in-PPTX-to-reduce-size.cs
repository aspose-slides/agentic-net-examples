using System;
using System.IO;
using Aspose.Slides.Export;

namespace ImageOptimizationExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output file paths
                string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_compressed.pptx");

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes[shapeIndex] as Aspose.Slides.IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Compress the image: delete cropped areas and set resolution to Dpi96 (minimum size)
                            pictureFrame.PictureFormat.CompressImage(true, Aspose.Slides.Export.PicturesCompression.Dpi96);
                        }
                    }
                }

                // Save the optimized presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}