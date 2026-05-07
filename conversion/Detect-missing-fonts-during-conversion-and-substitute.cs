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
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Define source (missing) and destination fonts
            IFontData sourceFont = new FontData("Calibri");
            IFontData destFont = new FontData("Arial");

            // Create a substitution rule that applies when the source font is inaccessible
            FontSubstRule substitutionRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            // Add the rule to a collection and assign it to the FontsManager
            FontSubstRuleCollection ruleCollection = new FontSubstRuleCollection();
            ruleCollection.Add(substitutionRule);
            presentation.FontsManager.FontSubstRuleList = ruleCollection;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}