// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Embed fonts and export to XPS using C#

//

// Description:

// Demonstrates how to load external fonts, embed missing fonts into a PowerPoint

// presentation, and export the presentation to XPS format using Aspose.Slides for .NET.

// The example includes font folder handling, font embedding, and XPS saving in a

// console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fonts, Embed Fonts, XPS Export,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Embed missing fonts into PPTX files before distribution.

// - Convert PowerPoint presentations to XPS format.

// - Build .NET tools for preparing presentations with proper font embedding.

// - Automate font management and XPS conversion in CI pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define paths

        string dataDir = "Data";

        string fontFolder = Path.Combine(dataDir, "Fonts");

        string inputPath = Path.Combine(dataDir, "input.pptx");

        string outputPath = Path.Combine(dataDir, "output.xps");



        // Verify input presentation exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input presentation not found: " + inputPath);

            return;

        }



        // Load external font folders (if they exist) before creating the presentation

        if (Directory.Exists(fontFolder))

        {

            string[] fontFolders = new string[] { fontFolder };

            FontsLoader.LoadExternalFonts(fontFolders);

        }

        else

        {

            Console.WriteLine("Font folder not found: " + fontFolder);

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Embed all fonts used in the presentation that are not already embedded

                IFontData[] allFonts = presentation.FontsManager.GetFonts();

                IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



                foreach (IFontData font in allFonts)

                {

                    bool alreadyEmbedded = false;

                    foreach (IFontData embedded in embeddedFonts)

                    {

                        if (embedded.FontName.Equals(font.FontName, StringComparison.OrdinalIgnoreCase))

                        {

                            alreadyEmbedded = true;

                            break;

                        }

                    }



                    if (!alreadyEmbedded)

                    {

                        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);

                    }

                }



                // Save the presentation as XPS

                XpsOptions xpsOptions = new XpsOptions();

                presentation.Save(outputPath, SaveFormat.Xps, xpsOptions);

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

            Console.WriteLine("Error: " + ex.Message);

        }

        finally

        {

            // Clear the font cache

            FontsLoader.ClearCache();

        }

    }

}

