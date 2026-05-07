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
        // Output SWF file paths for different ViewerIncluded settings
        string outputPathViewerFalse = "output_false.swf";
        string outputPathViewerTrue = "output_true.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Save SWF without viewer
                Aspose.Slides.Export.SwfOptions optionsFalse = new Aspose.Slides.Export.SwfOptions();
                optionsFalse.ViewerIncluded = false;
                presentation.Save(outputPathViewerFalse, Aspose.Slides.Export.SaveFormat.Swf, optionsFalse);

                // Save SWF with viewer
                Aspose.Slides.Export.SwfOptions optionsTrue = new Aspose.Slides.Export.SwfOptions();
                optionsTrue.ViewerIncluded = true;
                presentation.Save(outputPathViewerTrue, Aspose.Slides.Export.SaveFormat.Swf, optionsTrue);
            }

            // Retrieve file sizes
            long sizeFalse = new FileInfo(outputPathViewerFalse).Length;
            long sizeTrue = new FileInfo(outputPathViewerTrue).Length;

            // Output the comparison results
            Console.WriteLine("SWF size (ViewerIncluded = false): " + sizeFalse + " bytes");
            Console.WriteLine("SWF size (ViewerIncluded = true): " + sizeTrue + " bytes");
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or web services)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}