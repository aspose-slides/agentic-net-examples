// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to XPS default orientation using C#

//

// Description:

// Demonstrates how to load a PPTX file and export it to XPS format using the

// default orientation with Aspose.Slides for .NET. The example includes basic

// file existence checks, exception handling, and proper resource disposal.

// This pattern can be used to automate PPTX to XPS conversion in .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Export, Default, 

// Orientation, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to XPS with default settings.

// - Build command‑line tools for PowerPoint document transformation.

// - Integrate PPTX to XPS export functionality into larger .NET workflows.

// - Validate presentation rendering before distribution or printing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPptxToXps

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.xps";



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



                // Save the presentation to XPS format using default options

                presentation.Save(outputPath, SaveFormat.Xps);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation successfully exported to XPS: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format exception

                Console.WriteLine("The specified format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

