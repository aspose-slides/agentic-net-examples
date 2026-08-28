// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Disable compression for archival PPTX using C#

//

// Description:

// Demonstrates how to disable ZIP64 compression when saving a PowerPoint

// presentation for archival purposes using Aspose.Slides for .NET. The

// example loads an existing PPTX file, checks an archival flag, and saves the

// presentation with Zip64Mode set to Never to produce an uncompressed PPTX.

// This pattern can be used in console utilities or automated workflows that

// require non‑compressed PPTX files for long‑term storage.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Disable Compression, Archival,

// Zip64Mode, Presentation Processing, Office Automation

//

// Use Cases:

// - Create archival‑ready PPTX files without ZIP64 compression.

// - Build command‑line tools for PPTX compression management.

// - Integrate compression control into .NET applications handling PowerPoint.

// - Ensure PPTX files meet specific storage or compliance requirements.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace DisableCompressionExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Check if input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Example flag indicating archival status

            bool isArchival = true;



            try

            {

                DisableCompressionIfArchival(inputPath, outputPath, isArchival);

                Console.WriteLine("Presentation saved to: " + outputPath);

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

        }



        static void DisableCompressionIfArchival(string inputPath, string outputPath, bool isArchival)

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                if (isArchival)

                {

                    // Save without compression by setting Zip64Mode to Never (disable ZIP64)

                    PptxOptions options = new PptxOptions();

                    options.Zip64Mode = Zip64Mode.Never;

                    presentation.Save(outputPath, SaveFormat.Pptx, options);

                }

                else

                {

                    // Normal save with default compression

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }



                // Ensure the presentation is saved before exiting

                presentation.Dispose();

            }

        }

    }

}

