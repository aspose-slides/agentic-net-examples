using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define file paths
        string inputPath = "presentation.pptx";
        string outputSwfPath = "presentation.swf";
        string reportPath = "missing_fonts_report.txt";
        string savedPresentationPath = "presentation_saved.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Generate diagnostic report for missing fonts (substitutions)
                System.Text.StringBuilder reportBuilder = new System.Text.StringBuilder();
                reportBuilder.AppendLine("Missing Fonts Report");
                reportBuilder.AppendLine("--------------------");

                bool anyMissing = false;
                foreach (FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())
                {
                    anyMissing = true;
                    reportBuilder.AppendLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
                }

                if (!anyMissing)
                {
                    reportBuilder.AppendLine("No missing fonts detected.");
                }

                // Write the report to a text file
                File.WriteAllText(reportPath, reportBuilder.ToString());

                // Convert presentation to SWF format
                SwfOptions swfOptions = new SwfOptions();
                presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);

                // Save the presentation before exiting (optional copy)
                presentation.Save(savedPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Handle unsupported format scenario
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}