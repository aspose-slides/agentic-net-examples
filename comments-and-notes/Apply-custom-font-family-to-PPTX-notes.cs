// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply custom font family to PPTX notes using C#

//

// Description:

// Demonstrates how to replace an existing font family with a custom font family

// throughout a PowerPoint presentation, including slide notes, using Aspose.Slides

// for .NET. The example handles both missing source files (by creating a new

// presentation) and existing presentations, then saves the result.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Font Replacement, Custom Font,

// Notes, Presentation Processing, Office Automation

//

// Use Cases:

// - Ensure consistent font usage across slides and notes in a PPTX file.

// - Automate font family updates for corporate branding in PowerPoint decks.

// - Build .NET tools that modify or standardize fonts in existing presentations.

// - Generate new presentations with a predefined font when source files are absent.

// -----------------------------------------------------------------------------



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



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            // Create a new presentation when the source file is missing

            using (Presentation presentation = new Presentation())

            {

                // Define source and destination fonts for replacement

                IFontData sourceFont = new FontData("Arial");

                IFontData destFont = new FontData("Calibri");



                // Replace the font globally (applies to notes as well)

                presentation.FontsManager.ReplaceFont(sourceFont, destFont);



                // Save the presentation before exiting

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        else

        {

            try

            {

                // Load the existing presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Define source and destination fonts for replacement

                    IFontData sourceFont = new FontData("Arial");

                    IFontData destFont = new FontData("Calibri");



                    // Replace the font globally (applies to notes as well)

                    presentation.FontsManager.ReplaceFont(sourceFont, destFont);



                    // Save the modified presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (Exception ex)

            {

                // Handle exceptions such as unsupported file formats

                // Format not supported

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

