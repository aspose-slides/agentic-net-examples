using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output SWF file paths
        string outputSwfViewerFalse = "output_false.swf";
        string outputSwfViewerTrue = "output_true.swf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save SWF without viewer
                SwfOptions optionsFalse = new SwfOptions();
                optionsFalse.ViewerIncluded = false;
                presentation.Save(outputSwfViewerFalse, SaveFormat.Swf, optionsFalse);

                // Save SWF with viewer
                SwfOptions optionsTrue = new SwfOptions();
                optionsTrue.ViewerIncluded = true;
                presentation.Save(outputSwfViewerTrue, SaveFormat.Swf, optionsTrue);

                // Save the presentation before exiting (as per rule)
                presentation.Save("temp_saved.pptx", SaveFormat.Pptx);
            }

            // Compare file sizes
            long sizeFalse = new FileInfo(outputSwfViewerFalse).Length;
            long sizeTrue = new FileInfo(outputSwfViewerTrue).Length;

            Console.WriteLine($"SWF size with ViewerIncluded = false: {sizeFalse} bytes");
            Console.WriteLine($"SWF size with ViewerIncluded = true: {sizeTrue} bytes");
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}