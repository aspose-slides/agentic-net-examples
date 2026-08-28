// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Count slides in PPTX from file using C#

//

// Description:

// Demonstrates how to count the number of slides in a PPTX file using C#

// and Aspose.Slides for .NET. The example loads a presentation from a file

// path supplied via command‑line arguments, retrieves the slide count, and

// writes the result to the console. It also shows basic error handling for

// missing arguments, file‑not‑found, and processing exceptions.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Count Slides, Presentation,

// File I/O, Console Application, Office Automation

//

// Use Cases:

// - Automate slide‑count verification in batch processing of PPTX files.

// - Build command‑line tools for PowerPoint presentation analysis.

// - Integrate slide counting into larger .NET workflows or CI pipelines.

// - Validate presentation content before publishing or further transformation.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideCountApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Check if a file path argument is provided

            if (args.Length == 0)

            {

                Console.WriteLine("Please provide the path to a presentation file.");

                return;

            }



            string inputPath = args[0];



            // Verify that the file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("The specified file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Get the number of slides

                int slideCount = pres.Slides.Count;



                Console.WriteLine("Number of slides: " + slideCount);



                // Save the presentation before exiting (preserve original format if possible)

                pres.Save(inputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);

                // Format not supported

            }

        }

    }

}

