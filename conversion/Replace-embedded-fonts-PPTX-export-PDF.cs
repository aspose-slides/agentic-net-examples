// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace embedded fonts PPTX export PDF using C#

//

// Description:

// Demonstrates how to replace embedded fonts in a PPTX file with a system

// font and export the presentation to PDF using C# and Aspose.Slides for .NET.

// The example loads a presentation, substitutes each embedded font with Arial,

// and saves the result as a PDF document.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Replace, Embedded, Fonts,

// Pptx, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate replacement of embedded fonts before PDF conversion.

// - Build C# utilities for PowerPoint presentation processing.

// - Generate PDF output from PPTX files with consistent font usage.

// - Validate and standardize fonts in presentations prior to publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



namespace FontReplacementExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Get all embedded fonts in the presentation

                Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



                // Replace each embedded font with a system font (e.g., Arial)

                foreach (Aspose.Slides.IFontData embeddedFont in embeddedFonts)

                {

                    Aspose.Slides.IFontData sourceFont = embeddedFont;

                    Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Arial");

                    presentation.FontsManager.ReplaceFont(sourceFont, destFont);

                }



                // Save the modified presentation as PDF

                presentation.Save(outputPath, SaveFormat.Pdf);



                // Dispose the presentation object

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle errors such as unsupported format

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

