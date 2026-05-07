using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Log font substitutions that will occur during rendering
            foreach (var substitution in presentation.FontsManager.GetSubstitutions())
            {
                Console.WriteLine("{0} -> {1}", substitution.OriginalFontName, substitution.SubstitutedFontName);
            }

            // Set SWF conversion options (optional)
            var swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.Compressed = true; // example option

            // Save the presentation as SWF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}