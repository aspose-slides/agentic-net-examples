// -----------------------------------------------------------------------------
// Example: Compress picture frame image without quality loss using C#
//
// Description:
// Demonstrates how to compress picture frame images in a PowerPoint presentation
// without quality loss using C# and Aspose.Slides for .NET. The example iterates
// through all slides and picture frames, applying compression with cropped area
// removal and a target resolution of 150 DPI. The processed presentation is saved
// as a new PPTX file. This pattern can be used to optimize PPTX files for web
// distribution while preserving visual fidelity.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Picture, Frame,
// Image, Presentation Processing, Office Automation
//
// Use Cases:
// - Reduce file size of PPTX presentations by compressing embedded images.
// - Prepare PowerPoint files for web publishing with controlled DPI.
// - Automate image optimization in batch processing of presentations.
// - Integrate image compression into .NET applications handling PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompressPictureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            IPictureFrame pictureFrame = shape as IPictureFrame;
                            if (pictureFrame != null)
                            {
                                // Compress the image, delete cropped areas, target resolution 150 DPI (web)
                                bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
                                // Optionally, handle the result if needed
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
