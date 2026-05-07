using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output SWF files with different JPEG quality
        string swfPathLow = "output_low.swf";
        string swfPathHigh = "output_high.swf";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Save with low JPEG quality
                SwfOptions optionsLow = new SwfOptions();
                optionsLow.JpegQuality = 50;
                pres.Save(swfPathLow, SaveFormat.Swf, optionsLow);

                // Save with high JPEG quality
                SwfOptions optionsHigh = new SwfOptions();
                optionsHigh.JpegQuality = 100;
                pres.Save(swfPathHigh, SaveFormat.Swf, optionsHigh);
            }

            // Compare the two SWF files byte by byte
            byte[] lowBytes = File.ReadAllBytes(swfPathLow);
            byte[] highBytes = File.ReadAllBytes(swfPathHigh);

            bool areEqual = lowBytes.Length == highBytes.Length;
            if (areEqual)
            {
                for (int i = 0; i < lowBytes.Length; i++)
                {
                    if (lowBytes[i] != highBytes[i])
                    {
                        areEqual = false;
                        break;
                    }
                }
            }

            Console.WriteLine(areEqual ? "SWF files are identical." : "SWF files differ.");
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}