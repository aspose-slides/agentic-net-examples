// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation from file before font configuration using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation from a file while

// configuring custom font folders and memory‑based fonts before the load

// operation using Aspose.Slides for .NET. The example shows how to set up

// LoadOptions with DocumentLevelFontSources, enumerate the fonts used in the

// presentation, and save the result.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, LoadOptions, Font Configuration,

// Custom Fonts, DocumentLevelFontSources, Presentation Processing

//

// Use Cases:

// - Load presentations with custom fonts that are not installed on the system.

// - Build .NET tools that need to process PPTX files with specific font resources.

// - Automate font handling for PowerPoint automation scenarios.

// - Validate and transform presentations while ensuring correct font rendering.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // Font folders and font files

        string fontFolder1 = "fonts";

        string fontFolder2 = "morefonts";

        string fontPath1 = "fonts/CustomFont1.ttf";

        string fontPath2 = "fonts/CustomFont2.ttf";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load font data into memory

            byte[] fontData1 = File.ReadAllBytes(fontPath1);

            byte[] fontData2 = File.ReadAllBytes(fontPath2);



            // Configure load options with custom font sources

            LoadOptions loadOptions = new LoadOptions();

            loadOptions.DocumentLevelFontSources.FontFolders = new string[] { fontFolder1, fontFolder2 };

            loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { fontData1, fontData2 };



            // Load presentation with the specified load options

            using (Presentation presentation = new Presentation(inputPath, loadOptions))

            {

                // Example operation: list fonts used in the presentation

                IFontData[] fonts = presentation.FontsManager.GetFonts();

                foreach (IFontData font in fonts)

                {

                    Console.WriteLine("Font: " + font.FontName);

                }



                // Save the presentation before exiting

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // format not supported

            Console.WriteLine("File format not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

