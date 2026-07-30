// -----------------------------------------------------------------------------
// Example: Compress picture frame images losslessly and verify using C#
//
// Description:
// Demonstrates how to compress picture frame images losslessly and verify 
// using C# and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Picture, Frame, 
// Images, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate compress picture frame images losslessly and verify.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
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
            // Define input and output file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output_compressed.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Get the first picture frame on the slide
                IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

                if (picFrame != null)
                {
                    // Compress the image using a lossless resolution (DocumentResolution) and delete cropped areas
                    bool compressionResult = picFrame.PictureFormat.CompressImage(true, PicturesCompression.DocumentResolution);
                    Console.WriteLine("Compression successful: " + compressionResult);
                }
                else
                {
                    Console.WriteLine("No picture frame found on the first slide.");
                }

                // Save the compressed presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                // Verify file size reduction
                long originalSize = new FileInfo(inputPath).Length;
                long compressedSize = new FileInfo(outputPath).Length;
                long sizeDifference = originalSize - compressedSize;
                double reductionPercent = (originalSize > 0) ? (sizeDifference * 100.0 / originalSize) : 0;

                Console.WriteLine("Original size (bytes): " + originalSize);
                Console.WriteLine("Compressed size (bytes): " + compressedSize);
                Console.WriteLine("Size reduction (bytes): " + sizeDifference);
                Console.WriteLine("Reduction percentage: " + reductionPercent.ToString("F2") + "%");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for compression.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
