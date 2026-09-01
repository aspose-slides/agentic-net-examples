// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: List available font families after memory load using C#

//

// Description:

// Demonstrates how to list available font families after loading a custom

// font from memory using C# and Aspose.Slides for .NET. The example loads a

// presentation with a memory‑based font source, enumerates the fonts available

// to the presentation, and saves the document.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List, Available, Font,

// Families, Memory Font, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate listing of font families when custom fonts are supplied from memory.

// - Build C# tools for PowerPoint presentation processing with in‑memory fonts.

// - Validate font availability before rendering or converting presentations.

// - Integrate custom font handling into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontListingApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string presentationPath = "input.pptx";

            string fontPath = "customfonts/CustomFont.ttf";

            string outputPath = "output.pptx";



            // Verify that the input files exist

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            if (!File.Exists(fontPath))

            {

                Console.WriteLine("Font file not found: " + fontPath);

                return;

            }



            try

            {

                // Load font binary data

                byte[] fontData = File.ReadAllBytes(fontPath);



                // Set up load options with memory-based font source

                LoadOptions loadOptions = new LoadOptions();

                loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { fontData };



                // Load the presentation with the specified load options

                Presentation presentation = new Presentation(presentationPath, loadOptions);



                // Retrieve and list all font families available in the presentation

                IFontData[] fonts = presentation.FontsManager.GetFonts();

                Console.WriteLine("Available font families:");

                foreach (IFontData font in fonts)

                {

                    Console.WriteLine("- " + font.FontName);

                }



                // Save the presentation before exiting

                presentation.Save(outputPath, SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

