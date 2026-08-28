// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to SWF for legacy web using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to SWF format 

// using Aspose.Slides for .NET in a console application. The example loads a 

// presentation, configures SWF export options (e.g., disables the integrated 

// viewer), and saves the result as a SWF file suitable for legacy web 

// scenarios.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Export, Legacy Web, 

// Presentation Processing, Console Application

//

// Use Cases:

// - Convert PPTX files to SWF for embedding in legacy web pages.

// - Build automated tools that process PowerPoint presentations in .NET.

// - Generate SWF output without the built‑in viewer for custom viewers.

// - Integrate PowerPoint conversion into CI/CD pipelines or batch jobs.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationToSwf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Configure SWF export options

                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                    // Example: exclude the integrated viewer

                    swfOptions.ViewerIncluded = false;



                    // Save the presentation as SWF

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                }



                Console.WriteLine("Presentation successfully converted to SWF.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

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

