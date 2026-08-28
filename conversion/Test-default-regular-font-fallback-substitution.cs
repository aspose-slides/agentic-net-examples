// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test default regular font fallback substitution using C#

//

// Description:

// Demonstrates how to test the default regular font fallback substitution by

// converting a PowerPoint presentation to HTML with a non‑existent default

// regular font using Aspose.Slides for .NET. The example loads a PPTX file,

// applies HtmlOptions with an invalid DefaultRegularFont, saves the result as

// HTML, and prints the font substitution mappings that Aspose.Slides performed.

// It also saves the presentation back to PPTX after processing.

//

// Keywords:

// C#, PowerPoint, PPTX, HTML conversion, Aspose.Slides for .NET, Test, Default,

// Regular, Font, Font Substitution, Presentation Processing, Office Automation

//

// Use Cases:

// - Verify default regular font fallback substitution behavior.

// - Convert PPTX files to HTML while forcing font substitution.

// - Retrieve and log font substitution information for diagnostics.

// - Automate presentation processing workflows that require custom font handling.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputHtmlPath = "output.html";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            // Create HtmlOptions and set a non‑existent default regular font

            Aspose.Slides.Export.HtmlOptions htmlOpts = new Aspose.Slides.Export.HtmlOptions();

            htmlOpts.DefaultRegularFont = "NonExistentFontXYZ";



            // Save the presentation to HTML using the options

            pres.Save(outputHtmlPath, Aspose.Slides.Export.SaveFormat.Html, htmlOpts);



            // Output font substitution information

            foreach (Aspose.Slides.FontSubstitutionInfo substitution in pres.FontsManager.GetSubstitutions())

            {

                Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");

            }



            // Save the presentation before exiting

            pres.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine($"Error: {ex.Message}");

        }

    }

}

