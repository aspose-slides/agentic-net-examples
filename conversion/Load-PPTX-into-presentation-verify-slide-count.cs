// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX into presentation verify slide count using C#

//

// Description:

// Demonstrates how to load a PPTX file into an Aspose.Slides Presentation,

// retrieve the total number of slides, output the count to the console, and

// optionally save the presentation. The example includes basic file existence

// checking and exception handling for unsupported formats and other errors.

// This pattern can be used in console applications that need to validate or

// process PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Slide Count,

// Verify, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate loading a PPTX file and verifying its slide count.

// - Build C# utilities for PowerPoint validation before publishing.

// - Integrate slide‑count checks into larger .NET workflows.

// - Save or transform presentations after performing validation steps.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the input PPTX file

            string inputPath = "input.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            Aspose.Slides.Presentation presentation = null;

            try

            {

                // Load the presentation from the file

                presentation = new Aspose.Slides.Presentation(inputPath);



                // Get the total number of slides

                int slideCount = presentation.Slides.Count;

                Console.WriteLine("Total slide count: " + slideCount);



                // Save the presentation before exiting

                string outputPath = "output.pptx";

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

            finally

            {

                // Ensure resources are released

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }

        }

    }

}

