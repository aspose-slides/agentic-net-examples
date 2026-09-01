// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply Arabic fallback fonts using C#

//

// Description:

// Demonstrates how to add an Arabic fallback font rule to a PowerPoint presentation

// using Aspose.Slides for .NET. The example loads an existing PPTX file, adds a

// fallback rule for the Arabic Unicode range (0x0600–0x06FF) with a specified font,

// and saves the modified presentation. This pattern helps ensure Arabic text is

// rendered correctly when the original font does not support the required glyphs.

//

// Keywords:

// C#, Aspose.Slides, Arabic, Fallback Font, PowerPoint, PPTX, Presentation Processing

//

// Use Cases:

// - Add Arabic fallback fonts to existing presentations.

// - Ensure proper rendering of Arabic characters in PPTX files.

// - Automate font fallback configuration in .NET PowerPoint workflows.

// - Integrate presentation processing into C# applications.

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

                // Add a fallback rule for Arabic script (Unicode range 0x0600–0x06FF) using a suitable font

                IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                fallbackRules.Add(new FontFallBackRule(0x0600, 0x06FF, "Arial"));



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        // Handle unsupported file format exceptions

        catch (PptxUnsupportedFormatException ex)

        {

            // Format not supported

            Console.WriteLine("Unsupported PPTX format: " + ex.Message);

        }

        catch (PptUnsupportedFormatException ex)

        {

            // Format not supported

            Console.WriteLine("Unsupported PPT format: " + ex.Message);

        }

        // General exception handling

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

