// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Diagnostic report hidden slide omission count using C#

//

// Description:

// Demonstrates how to generate a diagnostic report of hidden slide omission count

// using C# and Aspose.Slides for .NET. The example loads a PPTX file, reads the

// total slide count and hidden slide count (which are omitted when

// ShowHiddenSlides is false), outputs the information to the console, and saves

// the presentation. This pattern helps automate PPTX diagnostics and validation

// in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Diagnostic, Report, Hidden,

// Slide, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate diagnostic reporting of hidden slide omission counts.

// - Build C# utilities for PowerPoint presentation analysis.

// - Validate slide visibility settings before publishing.

// - Integrate presentation diagnostics into larger .NET workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace DiagnosticTool

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

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

                Presentation pres = new Presentation(inputPath);



                // Retrieve slide counts

                int totalSlides = pres.DocumentProperties.Slides;

                int hiddenSlides = pres.DocumentProperties.HiddenSlides;

                int omittedSlides = hiddenSlides; // ShowHiddenSlides is false by default



                // Report the diagnostic information

                Console.WriteLine("Total slides in presentation: " + totalSlides);

                Console.WriteLine("Hidden slides omitted (ShowHiddenSlides = false): " + omittedSlides);



                // Save the presentation before exiting

                pres.Save(outputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other loading errors

                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);

                // Format not supported comment

                // Note: If the exception is due to an unsupported file format, the format is not supported.

            }

        }

    }

}

