using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Initialize fallback rules collection
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

        // Add fallback rules
        rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
        rules.Add(new Aspose.Slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho"));
        string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji" };
        rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));

        // Assign the collection to the presentation
        presentation.FontsManager.FontFallBackRulesCollection = rules;

        // Remove a specific rule by reference (second rule)
        Aspose.Slides.IFontFallBackRule ruleToRemove = rules[1];
        rules.Remove(ruleToRemove);

        // Remove a specific fallback font from the first rule
        Aspose.Slides.IFontFallBackRule firstRule = rules[0];
        firstRule.Remove("Times New Roman");

        // Save the presentation
        string outputPath = "Output.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}