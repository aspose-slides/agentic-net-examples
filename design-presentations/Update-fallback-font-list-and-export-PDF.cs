// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add fallback font rule and export PDF using Aspose.Slides for .NET

//

// Description:

// Demonstrates how to load a PowerPoint presentation, add a custom font fallback

// rule for a specific Unicode range, and then export the modified presentation

// to PDF using Aspose.Slides for .NET. The console application checks for the

// input file, updates the FontsManager with a new IFontFallBackRule, and saves

// the result as a PDF document.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, PDF, Font fallback, IFontFallBackRule,

// FontsManager, Presentation processing, Office automation

//

// Use Cases:

// - Programmatically add or modify font fallback rules in PPTX files.

// - Convert PowerPoint presentations to PDF after adjusting font handling.

// - Build .NET utilities for batch processing of presentations with custom fonts.

// - Ensure correct font rendering in exported PDFs when original fonts are missing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace UpdateFallbackFonts

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            // Check if the input file exists

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

                    // Get the existing fallback rules collection

                    IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;



                    // Create a new fallback rule for a Unicode range (example: Basic Latin)

                    IFontFallBackRule newRule = new FontFallBackRule(0x0020, 0x007F, "Arial");



                    // Add additional fallback fonts to the rule

                    newRule.AddFallBackFonts("Times New Roman");

                    newRule.AddFallBackFonts(new string[] { "Calibri", "Helvetica" });



                    // Add the new rule to the collection

                    fallbackRules.Add(newRule);



                    // Save the presentation as PDF

                    presentation.Save(outputPath, SaveFormat.Pdf);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Handle unsupported format scenario

                Console.WriteLine("The specified format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., external URL or web service errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

