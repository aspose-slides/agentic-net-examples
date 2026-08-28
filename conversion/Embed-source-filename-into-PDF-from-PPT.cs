// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Embed source filename into PDF from PPT using C#

//

// Description:

// Demonstrates how to embed source filename into PDF from PPT using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, PDF, Embed, Source, 

// Filename, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate embed source filename into PDF from PPT.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertPptToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input and output paths

            string inputPath;

            string outputPath;

            if (args.Length >= 2)

            {

                inputPath = args[0];

                outputPath = args[1];

            }

            else

            {

                inputPath = "sample.pptx";

                outputPath = Path.ChangeExtension(inputPath, ".pdf");

            }



            // Verify that the input file exists

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

                    // Embed the source filename as a document property (Title)

                    IDocumentProperties documentProperties = presentation.DocumentProperties;

                    documentProperties.Title = Path.GetFileName(inputPath);



                    // Save the presentation as PDF

                    presentation.Save(outputPath, SaveFormat.Pdf);

                }

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // TODO: Add handling for unsupported file formats if needed

            }

        }

    }

}

