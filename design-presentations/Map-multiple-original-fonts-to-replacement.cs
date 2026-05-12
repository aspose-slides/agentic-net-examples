using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Original fonts to be replaced
                string[] sourceFonts = new string[] { "Arial", "Calibri", "Times New Roman" };
                // Single replacement font
                string replacementFont = "Verdana";

                // Create a collection of substitution rules
                IFontSubstRuleCollection substRules = new FontSubstRuleCollection();

                foreach (string src in sourceFonts)
                {
                    IFontData sourceFontData = new FontData(src);
                    IFontData destFontData = new FontData(replacementFont);
                    FontSubstRule rule = new FontSubstRule(sourceFontData, destFontData, FontSubstCondition.Always);
                    substRules.Add(rule);
                }

                // Apply the substitution rules to the presentation
                presentation.FontsManager.FontSubstRuleList = substRules;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}