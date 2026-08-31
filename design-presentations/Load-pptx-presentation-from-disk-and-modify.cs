// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load pptx presentation from disk and modify built‑in document properties using C#

//

// Description:

// Demonstrates how to load a PPTX presentation from disk, modify its built‑in

// document properties (Author, Title, Subject) using Aspose.Slides for .NET, and

// save the updated file. The example includes file existence checking, error

// handling, and proper resource disposal, suitable for console applications that

// automate PowerPoint metadata processing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, DocumentProperties, Author,

// Title, Subject, Presentation, Disk, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate updating metadata of existing PPTX files.

// - Build C# tools for batch processing of PowerPoint document properties.

// - Integrate presentation metadata management into .NET applications.

// - Validate and standardize PPTX metadata before distribution.

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

                // Load the presentation from disk

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Access built‑in document properties

                Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;



                // Modify built‑in properties

                documentProperties.Author = "Aspose.Slides for .NET";

                documentProperties.Title = "Modified Presentation";

                documentProperties.Subject = "Demo";



                // Save the modified presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



                // Release resources

                presentation.Dispose();



                Console.WriteLine("Presentation modified and saved to: " + outputPath);

            }

            catch (Exception ex)

            {

                // Handle exceptions (e.g., unsupported format)

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported

            }

        }

    }

}

