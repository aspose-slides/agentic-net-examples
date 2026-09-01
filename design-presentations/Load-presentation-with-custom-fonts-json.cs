// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation with custom fonts and output font list as JSON using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation with custom font folders

// and in‑memory fonts using Aspose.Slides for .NET, retrieve the fonts used in

// the presentation, serialize the font information to JSON, and save the

// presentation. The example shows the required steps for handling custom fonts

// and generating JSON output in a standalone console application. Developers can

// use this pattern to automate PPTX workflows, validate font usage, or integrate

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Custom Fonts,

// FontManager, JSON, Serialization, Office Automation

//

// Use Cases:

// - Load a presentation with custom font folders and memory fonts.

// - Export the list of fonts used in a presentation to JSON.

// - Build C# tools for PowerPoint font management and processing.

// - Validate and troubleshoot font dependencies in PPTX files.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Text.Json;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontManagerExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define file and folder paths

            string inputPresentationPath = "input.pptx";

            string outputPresentationPath = "output.pptx";

            string fontFolder1 = "fonts\\folder1";

            string fontFolder2 = "fonts\\folder2";

            string fontPath1 = "fonts\\custom1.ttf";

            string fontPath2 = "fonts\\custom2.ttf";



            // Verify that the input presentation exists

            if (!File.Exists(inputPresentationPath))

            {

                Console.WriteLine("Input presentation file does not exist: " + inputPresentationPath);

                return;

            }



            // Verify that font files exist

            if (!File.Exists(fontPath1) || !File.Exists(fontPath2))

            {

                Console.WriteLine("One or more font files are missing.");

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



                // Load the presentation with the specified load options

                Presentation presentation = new Presentation(inputPresentationPath, loadOptions);



                // Retrieve fonts used in the presentation

                IFontData[] fonts = presentation.FontsManager.GetFonts();



                // Prepare a simple object for JSON serialization

                var fontInfoList = new System.Collections.Generic.List<object>();

                foreach (IFontData font in fonts)

                {

                    fontInfoList.Add(new { FontName = font.FontName });

                }



                // Serialize fonts manager configuration to JSON

                string json = JsonSerializer.Serialize(fontInfoList, new JsonSerializerOptions { WriteIndented = true });

                Console.WriteLine("FontsManager configuration:");

                Console.WriteLine(json);



                // Save the presentation before exiting

                presentation.Save(outputPresentationPath, SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

