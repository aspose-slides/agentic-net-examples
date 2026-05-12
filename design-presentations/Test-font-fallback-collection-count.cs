using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Retrieve the FontFallBack rules collection
                IFontFallBackRulesCollection rules = presentation.FontsManager.FontFallBackRulesCollection;

                // Add expected rules
                rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                rules.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho"));

                // Assert that the collection contains the expected number of rules
                int expectedCount = 2;
                if (rules.Count != expectedCount)
                {
                    throw new Exception("FontFallBackRulesCollection count mismatch. Expected " + expectedCount + " but was " + rules.Count);
                }

                // Save the presentation before exiting
                presentation.Save("FontFallbackTest.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}