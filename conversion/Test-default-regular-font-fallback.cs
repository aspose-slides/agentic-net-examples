using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Set a non‑existent default regular font
                HtmlOptions htmlOpts = new HtmlOptions();
                htmlOpts.DefaultRegularFont = "NonExistentFont";

                // Output HTML path
                string outputPath = "output.html";

                // Save presentation with the specified default font
                pres.Save(outputPath, SaveFormat.Html, htmlOpts);

                // Display font substitution information
                foreach (FontSubstitutionInfo substitution in pres.FontsManager.GetSubstitutions())
                {
                    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
                }

                // Ensure presentation is saved before exit
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // (If the format is not supported, an exception will be caught here)
            }
        }
    }
}