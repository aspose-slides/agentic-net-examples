using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TestSwfJpegQuality
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "test_input.pptx";
            string outputPath = "test_output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Test setting JpegQuality to the lower boundary (0)
                SwfOptions swfOptionsLow = new SwfOptions();
                swfOptionsLow.JpegQuality = 0;
                Console.WriteLine("JpegQuality set to 0: " + swfOptionsLow.JpegQuality);

                // Test setting JpegQuality to the upper boundary (100)
                SwfOptions swfOptionsHigh = new SwfOptions();
                swfOptionsHigh.JpegQuality = 100;
                Console.WriteLine("JpegQuality set to 100: " + swfOptionsHigh.JpegQuality);

                // Test setting JpegQuality to an invalid negative value
                try
                {
                    SwfOptions swfOptionsNeg = new SwfOptions();
                    swfOptionsNeg.JpegQuality = -1;
                    Console.WriteLine("JpegQuality set to -1: " + swfOptionsNeg.JpegQuality);
                }
                catch (Exception ex)
                {
                    // Expected exception for out-of-range value
                    Console.WriteLine("Exception when setting JpegQuality to -1: " + ex.Message);
                }

                // Test setting JpegQuality to an invalid value above 100
                try
                {
                    SwfOptions swfOptionsOver = new SwfOptions();
                    swfOptionsOver.JpegQuality = 101;
                    Console.WriteLine("JpegQuality set to 101: " + swfOptionsOver.JpegQuality);
                }
                catch (Exception ex)
                {
                    // Expected exception for out-of-range value
                    Console.WriteLine("Exception when setting JpegQuality to 101: " + ex.Message);
                }

                // Save the presentation using a valid SwfOptions instance
                try
                {
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptionsHigh);
                    Console.WriteLine("Presentation saved to " + outputPath);
                }
                catch (NotSupportedException)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("SaveFormat.Swf is not supported in this environment.");
                }
                catch (Exception ex)
                {
                    // General exception handling for save operation
                    Console.WriteLine("Error during saving: " + ex.Message);
                }
            }
        }
    }
}