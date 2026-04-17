using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CropPictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Find the first picture frame on the slide
                    IPictureFrame pictureFrame = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        pictureFrame = shape as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            break;
                        }
                    }

                    if (pictureFrame == null)
                    {
                        Console.WriteLine("No picture frame found on the first slide.");
                    }
                    else
                    {
                        // Crop 10% from the top and 5% from the bottom
                        pictureFrame.PictureFormat.CropTop = 0.10f;    // 10 percent
                        pictureFrame.PictureFormat.CropBottom = 0.05f; // 5 percent
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (including missing SlidesException type)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}