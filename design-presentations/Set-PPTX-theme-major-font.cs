// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set PPTX theme major font using C#

//

// Description:

// Demonstrates how to change the major font of a PowerPoint presentation's

// theme to a specified font using Aspose.Slides for .NET. The example loads an

// existing PPTX file, updates the Latin major font in the theme's font scheme,

// and saves the result as a new PPTX file. This pattern can be used in console

// applications or integrated into larger .NET solutions for automated

// presentation styling.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Theme, Major Font, FontScheme,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Programmatically set or replace the major font in a PPTX theme.

// - Build tools that enforce corporate branding fonts across presentations.

// - Automate batch processing of PowerPoint files to apply a consistent font.

// - Validate and modify presentation styles before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

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

                Presentation presentation = new Presentation(inputPath);



                // Create a FontData instance for the new major font

                FontData newMajorFont = new FontData("Calibri");



                // Assign the new font to the theme's major font collection (Latin font)

                presentation.MasterTheme.FontScheme.Major.LatinFont = newMajorFont;



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation saved successfully to: " + outputPath);

            }

            catch (Aspose.Slides.PptxReadException)

            {

                // Handle unsupported file format

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URL or web service errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

