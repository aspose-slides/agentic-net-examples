using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Define source and destination fonts
                Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
                Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Calibri");

                // Create a font substitution rule (always substitute)
                Aspose.Slides.IFontSubstRule substRule = new Aspose.Slides.FontSubstRule(sourceFont, destFont, Aspose.Slides.FontSubstCondition.Always);

                // Create a collection of substitution rules and add the rule
                Aspose.Slides.IFontSubstRuleCollection substRules = new Aspose.Slides.FontSubstRuleCollection();
                substRules.Add(substRule);

                // Apply the substitution rules to the presentation
                pres.FontsManager.FontSubstRuleList = substRules;

                // Save the presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}