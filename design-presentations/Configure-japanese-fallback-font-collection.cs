using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesFallbackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the fallback rules collection from the FontsManager
                IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                // Japanese Unicode range (Hiragana and Katakana)
                uint rangeStart = 0x3040;
                uint rangeEnd = 0x30FF;

                // Define three prioritized fonts for the fallback rule
                string[] japaneseFonts = new string[] { "MS Mincho", "MS Gothic", "Yu Gothic" };
                FontFallBackRule japaneseRule = new FontFallBackRule(rangeStart, rangeEnd, japaneseFonts);

                // Add the rule to the collection
                fallbackRules.Add(japaneseRule);

                // (Optional) assign the modified collection back to the manager
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Define output file path
                string outputPath = "FallbackExample.pptx";

                // Ensure the output directory exists
                string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions (e.g., I/O errors)
            }
        }
    }
}