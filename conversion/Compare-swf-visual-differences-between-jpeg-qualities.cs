using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfComparisonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = Path.Combine(Environment.CurrentDirectory, "SamplePresentation.pptx");
            // Output SWF paths
            string outputSwfLowQuality = Path.Combine(Environment.CurrentDirectory, "OutputLowQuality.swf");
            string outputSwfHighQuality = Path.Combine(Environment.CurrentDirectory, "OutputHighQuality.swf");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save with low JPEG quality
                    SwfOptions swfOptionsLow = new SwfOptions();
                    swfOptionsLow.JpegQuality = 50; // Low quality
                    presentation.Save(outputSwfLowQuality, SaveFormat.Swf, swfOptionsLow);

                    // Save with high JPEG quality
                    SwfOptions swfOptionsHigh = new SwfOptions();
                    swfOptionsHigh.JpegQuality = 100; // High quality
                    presentation.Save(outputSwfHighQuality, SaveFormat.Swf, swfOptionsHigh);
                }

                // Compare the generated SWF files (size as a simple visual difference metric)
                FileInfo lowInfo = new FileInfo(outputSwfLowQuality);
                FileInfo highInfo = new FileInfo(outputSwfHighQuality);

                Console.WriteLine("Low quality SWF size: " + lowInfo.Length + " bytes");
                Console.WriteLine("High quality SWF size: " + highInfo.Length + " bytes");

                if (lowInfo.Length == highInfo.Length)
                {
                    Console.WriteLine("SWF files are identical in size; visual differences may be minimal.");
                }
                else
                {
                    Console.WriteLine("SWF files differ in size, indicating visual differences due to JPEG quality.");
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, Aspose.Slides exceptions)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}