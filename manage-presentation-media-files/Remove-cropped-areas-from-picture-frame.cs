// -----------------------------------------------------------------------------
// Example: Remove cropped areas from picture frame using C#
//
// Description:
// Demonstrates how to remove cropped areas from a picture frame using C# and 
// Aspose.Slides for .NET. The example loads a PPTX file, accesses the first 
// picture frame on the first slide, deletes any cropped areas of the picture, 
// and saves the modified presentation. This pattern can be used to clean up 
// presentations by removing unnecessary image cropping data.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Cropped, Areas, 
// Picture, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of cropped areas from picture frames in presentations.
// - Build C# tools for PowerPoint presentation cleanup and optimization.
// - Generate or transform PPTX files in .NET applications while ensuring 
//   images are stored without cropping metadata.
// - Validate and prepare presentations before publishing or integration.
// -----------------------------------------------------------------------------
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
