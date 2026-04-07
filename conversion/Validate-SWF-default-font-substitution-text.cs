using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Configure SWF options with default regular font substitution
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.DefaultRegularFont = "Arial";

            // Save presentation as SWF
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Verify font substitutions applied
            foreach (Aspose.Slides.FontSubstitutionInfo fontSubstitution in pres.FontsManager.GetSubstitutions())
            {
                Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
            }

            // Save presentation before exit (optional, ensures changes are persisted)
            pres.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}