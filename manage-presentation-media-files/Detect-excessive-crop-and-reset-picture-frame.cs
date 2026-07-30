// -----------------------------------------------------------------------------
// Example: Detect excessive crop and reset picture frame using C#
//
// Description:
// Demonstrates how to detect picture frames with cropping applied and
// delete the cropped areas, effectively resetting the picture frame using
// Aspose.Slides for .NET. The example loads a PPTX file, processes each slide,
// removes cropping from picture frames, and saves the updated presentation.
// This pattern can be used to clean up presentations before publishing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Excessive, Crop, Reset,
// Picture Frame, Delete Cropped Areas, Presentation Processing, Office Automation
//
// Use Cases:
// - Detect and remove excessive cropping from picture frames in PPTX files.
// - Automate cleanup of presentations to ensure images are not unintentionally cropped.
// - Build .NET tools for PowerPoint presentation processing and validation.
// - Integrate picture frame normalization into document workflows.
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
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IPictureFrame picFrame = slide.Shapes[shapeIndex] as IPictureFrame;
                            if (picFrame != null)
                            {
                                // Check if any cropping is applied (values not equal to 0)
                                bool hasCropping = picFrame.PictureFormat.CropLeft != 0 ||
                                                   picFrame.PictureFormat.CropTop != 0 ||
                                                   picFrame.PictureFormat.CropRight != 0 ||
                                                   picFrame.PictureFormat.CropBottom != 0;

                                if (hasCropping)
                                {
                                    // Delete cropped areas and reset cropping to default
                                    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();
                                    // croppedImage can be used if needed
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
