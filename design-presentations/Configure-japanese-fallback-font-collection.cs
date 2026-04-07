using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Create a fallback rules collection
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

        // Define three fonts to prioritize for the Japanese Unicode range (0x3040 - 0x30FF)
        string[] japaneseFonts = new string[] { "MS Mincho", "MS Gothic", "Yu Gothic" };
        rules.Add(new Aspose.Slides.FontFallBackRule(0x3040u, 0x30FFu, japaneseFonts));

        // Assign the collection to the presentation's FontsManager
        pres.FontsManager.FontFallBackRulesCollection = rules;

        // Save the presentation
        try
        {
            pres.Save("JapaneseFallback.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        pres.Dispose();
    }
}