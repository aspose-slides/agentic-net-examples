// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load custom font directory, register fonts, and apply fallback rules using C#

//

// Description:

// Demonstrates how to load a custom font directory, register external fonts,

// define font fallback rules, and apply them to a presentation using Aspose.Slides for .NET.

// The example also renders the first slide to a PNG image and saves the modified

// presentation. This pattern is useful for handling missing fonts and ensuring correct

// text rendering in PowerPoint files.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, custom fonts, font fallback, FontsLoader, FontsManager, image export, presentation processing

//

// Use Cases:

// - Load and register external fonts for presentations.

// - Define and apply font fallback rules for specific Unicode ranges.

// - Export slides as images after font handling.

// - Save updated presentations with applied font settings.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Paths

            string inputPath = "input.pptx";

            string outputPath = "output.png";

            string outputPresentationPath = "output.pptx";

            string fontsDirectory = "customfonts";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Verify fonts directory exists

            if (!Directory.Exists(fontsDirectory))

            {

                Console.WriteLine("Fonts directory does not exist: " + fontsDirectory);

                return;

            }



            try

            {

                // Load custom fonts from the specified directory

                string[] fontFolders = new string[] { fontsDirectory };

                FontsLoader.LoadExternalFonts(fontFolders);



                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Create fallback rules collection

                IFontFallBackRulesCollection fallbackRules = new FontFallBackRulesCollection();



                // Example fallback rule: Unicode range 0x400-0x4FF uses "Times New Roman"

                FontFallBackRule rule = new FontFallBackRule(0x400, 0x4FF, "Times New Roman");

                fallbackRules.Add(rule);



                // Register fallback rules with the presentation's FontsManager

                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;



                // Render first slide to an image

                IImage slideImage = presentation.Slides[0].GetImage(1f, 1f);

                slideImage.Save(outputPath, ImageFormat.Png);

                slideImage.Dispose();



                // Save the presentation after applying fallback rules

                presentation.Save(outputPresentationPath, SaveFormat.Pptx);

                presentation.Dispose();



                // Clear loaded custom fonts from cache

                FontsLoader.ClearCache();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                // Format not supported

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

