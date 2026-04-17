using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideImageCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate over slides beyond the tenth slide (index 10 and higher)
                for (int slideIndex = 10; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a picture frame
                        Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Compress the image: delete cropped areas and set resolution to Dpi96
                            bool compressionResult = pictureFrame.PictureFormat.CompressImage(
                                true,
                                Aspose.Slides.Export.PicturesCompression.Dpi96);

                            // Optional: log compression result
                            Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}: Compression {(compressionResult ? "succeeded" : "failed")}");
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}