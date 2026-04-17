using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteCroppedAreasExample
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
                Presentation pres = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Get the first shape as a picture frame
                IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

                if (picFrame != null)
                {
                    // Delete cropped areas of the picture
                    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();
                    // croppedImage can be used if needed
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle format not supported or other exceptions
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}