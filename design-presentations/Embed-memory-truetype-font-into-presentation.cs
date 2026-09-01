// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Embed memory truetype font into presentation using C#

//

// Description:

// Demonstrates how to embed a TrueType font loaded from memory into a PowerPoint

// presentation using Aspose.Slides for .NET. The example loads an existing PPTX,

// reads a .ttf file into a byte array, embeds the font (all characters) into the

// presentation, and saves the result as a new PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Embed, Memory, Truetype, Font,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate embedding of memory-loaded TrueType fonts into presentations.

// - Build C# utilities for PowerPoint presentation processing.

// - Generate or transform PPTX files with embedded fonts in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontEmbeddingExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Paths for the input presentation, output presentation, and the TrueType font file

            string inputPresentationPath = "input.pptx";

            string outputPresentationPath = "output.pptx";

            string fontFilePath = "customfont.ttf";



            // Verify that the input presentation exists

            if (!File.Exists(inputPresentationPath))

            {

                Console.WriteLine("Input presentation file not found: " + inputPresentationPath);

                return;

            }



            // Verify that the font file exists

            if (!File.Exists(fontFilePath))

            {

                Console.WriteLine("Font file not found: " + fontFilePath);

                return;

            }



            // Load the presentation

            Presentation presentation = new Presentation(inputPresentationPath);



            try

            {

                // Load the TrueType font into memory

                byte[] fontData = File.ReadAllBytes(fontFilePath);



                // Embed the font into the presentation (embed all characters)

                presentation.FontsManager.AddEmbeddedFont(fontData, EmbedFontCharacters.All);

            }

            catch (Exception ex)

            {

                // Handle any errors that occur while loading or embedding the font

                Console.WriteLine("Error embedding font: " + ex.Message);

                // Continue without embedding if necessary

            }



            try

            {

                // Save the presentation with the embedded font

                presentation.Save(outputPresentationPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other save errors

                Console.WriteLine("Error saving presentation: " + ex.Message);

                // Comment: format not supported

            }



            // Dispose the presentation object

            presentation.Dispose();

        }

    }

}

