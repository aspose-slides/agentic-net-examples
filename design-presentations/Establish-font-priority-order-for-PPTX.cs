using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Create a new presentation
            presentation = new Aspose.Slides.Presentation();

            // Create a new fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Fallback for Basic Latin (U+0020 to U+007F) – primary font Arial, secondary Helvetica
            Aspose.Slides.IFontFallBackRule latinRule = new Aspose.Slides.FontFallBackRule(0x0020u, 0x007Fu, "Arial");
            latinRule.AddFallBackFonts("Helvetica");
            rules.Add(latinRule);

            // Fallback for Cyrillic (U+0400 to U+04FF) – primary font Times New Roman
            Aspose.Slides.IFontFallBackRule cyrillicRule = new Aspose.Slides.FontFallBackRule(0x0400u, 0x04FFu, "Times New Roman");
            rules.Add(cyrillicRule);

            // Fallback for Emoji (U+1F600 to U+1F64F) – multiple fallback fonts
            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji", "Noto Color Emoji" };
            Aspose.Slides.IFontFallBackRule emojiRule = new Aspose.Slides.FontFallBackRule(0x1F600u, 0x1F64Fu, emojiFonts);
            rules.Add(emojiRule);

            // Assign the collection to the presentation
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            presentation.Save("FontPriorityDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}