using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompressImagesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_compressed.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides and shapes to compress picture frames
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        if (shape is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;
                            // Compress the image: delete cropped areas and set resolution to 150 DPI (good for web)
                            bool compressed = pictureFrame.PictureFormat.CompressImage(true, Aspose.Slides.Export.PicturesCompression.Dpi150);
                            // Optionally, you could log the result
                            // Console.WriteLine($"Image compressed: {compressed}");
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}