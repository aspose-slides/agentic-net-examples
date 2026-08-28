// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create PPTX to SWF embed font subset using C#

//

// Description:

// Demonstrates how to convert a PPTX file to SWF while embedding only the

// subset of fonts used in the presentation. The example loads a custom TrueType

// font into the Aspose.Slides font cache, embeds the required characters for

// each font, configures SWF options, and saves the result as an SWF file.

// This pattern can be used in console applications to automate PPTX to SWF

// conversion with font subsetting.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Font Embedding, Subset,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to SWF with embedded font subsets.

// - Build C# tools that ensure correct font rendering in SWF output.

// - Automate batch conversion of PowerPoint files while minimizing file size.

// - Integrate font‑aware PPTX to SWF conversion into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontEmbeddedSwfExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation and custom font paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";

            string fontPath = "customfont.ttf";



            // Verify input files exist

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input presentation file not found.");

                return;

            }

            if (!File.Exists(fontPath))

            {

                Console.WriteLine("Custom font file not found.");

                return;

            }



            try

            {

                // Load custom font into Aspose.Slides font cache

                byte[] customFontData = File.ReadAllBytes(fontPath);

                FontsLoader.LoadExternalFont(customFontData);



                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Embed each font used in the presentation (subset only)

                IFontData[] allFonts = presentation.FontsManager.GetFonts();

                if (allFonts != null && allFonts.Length > 0)

                {

                    foreach (IFontData font in allFonts)

                    {

                        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.OnlyUsed);

                    }

                }



                // Configure SWF options (optional settings)

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.DefaultRegularFont = "Arial"; // fallback font if needed



                // Save as SWF

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Dispose presentation

                presentation.Dispose();



                // Clear loaded custom fonts from cache

                FontsLoader.ClearCache();



                Console.WriteLine("SWF file created successfully.");

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // If the exception indicates an unsupported format, the format is not supported.

            }

        }

    }

}

