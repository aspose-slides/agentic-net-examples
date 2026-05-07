using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputHtmlPath = "output.html";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Create HtmlOptions and set a non‑existent default regular font
            Aspose.Slides.Export.HtmlOptions htmlOpts = new Aspose.Slides.Export.HtmlOptions();
            htmlOpts.DefaultRegularFont = "NonExistentFontXYZ";

            // Save the presentation to HTML using the options
            pres.Save(outputHtmlPath, Aspose.Slides.Export.SaveFormat.Html, htmlOpts);

            // Output font substitution information
            foreach (Aspose.Slides.FontSubstitutionInfo substitution in pres.FontsManager.GetSubstitutions())
            {
                Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
            }

            // Save the presentation before exiting
            pres.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}