using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontSubstitutionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for the output presentation
                string outputPath = "SubstitutedPresentation.pptx";

                // Create a new empty presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Define source and destination fonts for substitution
                Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
                Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Calibri");

                // Create a substitution rule that always replaces the source font with the destination font
                Aspose.Slides.IFontSubstRule substRule = new Aspose.Slides.FontSubstRule(sourceFont, destFont, Aspose.Slides.FontSubstCondition.Always);

                // Create a collection of substitution rules and add the rule
                Aspose.Slides.IFontSubstRuleCollection substRules = new Aspose.Slides.FontSubstRuleCollection();
                substRules.Add(substRule);

                // Assign the substitution rules to the presentation's FontsManager
                pres.FontsManager.FontSubstRuleList = substRules;

                // Save the presentation with the applied font substitution
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Release resources
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}