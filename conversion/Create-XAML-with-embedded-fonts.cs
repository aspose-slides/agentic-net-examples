using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get all fonts used in the presentation
                    IFontData[] allFonts = presentation.FontsManager.GetFonts();

                    // Get fonts that are already embedded
                    IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                    // Embed any fonts that are not already embedded
                    foreach (IFontData font in allFonts)
                    {
                        bool isEmbedded = embeddedFonts.Any(ef => ef.FontName.Equals(font.FontName, StringComparison.OrdinalIgnoreCase));
                        if (!isEmbedded)
                        {
                            presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                        }
                    }

                    // Save the presentation as XAML with embedded fonts
                    XamlOptions xamlOptions = new XamlOptions();
                    xamlOptions.ExportHiddenSlides = true;
                    presentation.Save(xamlOptions);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}