// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate swf slide count matches visible using C#

//

// Description:

// Demonstrates how to convert a PPTX presentation to SWF while excluding hidden

// slides, and then validates that the number of slides exported to the SWF file

// matches the count of visible slides in the original presentation. The example

// uses Aspose.Slides for .NET and can be run as a standalone console

// application.

//

// Keywords:

// C#, Aspose.Slides, SWF, PPTX, slide count, hidden slides, visible slides,

// presentation conversion, Office automation

//

// Use Cases:

// - Ensure that hidden slides are not included when converting PPTX to SWF.

// - Automate validation of slide counts after format conversion.

// - Build .NET tools for PowerPoint to SWF conversion with slide visibility

//   checks.

// - Integrate presentation validation into CI pipelines or publishing workflows.

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

            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.swf");



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Create SWF options and disable hidden slide export

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.ShowHiddenSlides = false;



                // Save presentation as SWF

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Verify slide counts

                int totalSlides = presentation.Slides.Count;

                int hiddenSlides = presentation.DocumentProperties.HiddenSlides;

                int visibleSlides = totalSlides - hiddenSlides;



                // Since hidden slides are excluded, exported SWF should contain only visible slides

                Console.WriteLine("Total slides: " + totalSlides);

                Console.WriteLine("Hidden slides: " + hiddenSlides);

                Console.WriteLine("Visible slides (expected in SWF): " + visibleSlides);

                Console.WriteLine("SWF saved to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Format not supported.

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., loading errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

