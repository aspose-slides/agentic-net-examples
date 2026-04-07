using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ShowHiddenSlides = true;
                // Save as SWF with default compression
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported.
            }
        }
    }
}