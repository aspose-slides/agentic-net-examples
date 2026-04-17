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

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            // Create a new presentation if input does not exist
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            // Add a blank slide
            pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            // Create fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
            // Cyrillic range fallback to Arial
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial"));
            // Greek range fallback to Times New Roman
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0370, 0x03FF, "Times New Roman"));
            // Emoji range fallback to preferred emoji fonts
            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));

            // Assign the rules to the presentation
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }

            pres.Dispose();
        }
        else
        {
            // Load existing presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported
                return;
            }

            // Create fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
            // Cyrillic range fallback to Arial
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial"));
            // Greek range fallback to Times New Roman
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0370, 0x03FF, "Times New Roman"));
            // Emoji range fallback to preferred emoji fonts
            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));

            // Assign the rules to the presentation
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }

            pres.Dispose();
        }
    }
}