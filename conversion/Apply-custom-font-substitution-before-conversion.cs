using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyCustomFontSubstitution
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Create source and destination font data
                    IFontData sourceFont = new FontData("Arial");
                    IFontData destFont = new FontData("Times New Roman");

                    // Create a substitution rule that always replaces the source font with the destination font
                    FontSubstRule substitutionRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.Always);

                    // Add the rule to the presentation's font substitution list
                    presentation.FontsManager.FontSubstRuleList.Add(substitutionRule);

                    // Save the presentation in PDF format
                    presentation.Save(outputPath, SaveFormat.Pdf);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified output format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}