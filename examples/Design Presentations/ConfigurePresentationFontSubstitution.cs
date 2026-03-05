using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Define the source (missing) font and the substitute font
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("NonExistingFont");
        Aspose.Slides.IFontData substituteFont = new Aspose.Slides.FontData("Arial");

        // Create a substitution rule that applies when the source font is not found
        Aspose.Slides.FontSubstRule substitutionRule = new Aspose.Slides.FontSubstRule(sourceFont, substituteFont, Aspose.Slides.FontSubstCondition.WhenInaccessible);

        // Add the rule to the presentation's FontsManager
        presentation.FontsManager.FontSubstRuleList.Add(substitutionRule);

        // Save the presentation
        presentation.Save("SubstitutedFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}