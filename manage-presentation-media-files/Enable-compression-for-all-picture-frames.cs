// -----------------------------------------------------------------------------
// Example: Enable compression for all picture frames using C#
//
// Description:
// Demonstrates how to enable compression for all picture frames in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads a PPTX
// file, iterates through each slide and picture frame, applies image compression
// (including removal of cropped areas) with a DPI of 96, and saves the result.
// This pattern can be used to automate PPTX workflows, reduce file size, or
// integrate presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Compression, Picture,
// Frames, Presentation Processing, Office Automation
//
// Use Cases:
// - Reduce the size of PowerPoint files by compressing all embedded images.
// - Build C# tools for batch processing of PPTX presentations.
// - Integrate image compression into document generation pipelines.
// - Validate and optimize presentation assets before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompressAllPictures
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_compressed.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IPictureFrame pictureFrame = slide.Shapes[shapeIndex] as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Compress image, delete cropped areas, use Dpi96 (minimum size) as example
                            pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi96);
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
