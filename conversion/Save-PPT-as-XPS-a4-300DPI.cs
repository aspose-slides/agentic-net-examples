// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPT as XPS a4 300DPI using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, set the slide size to

// A4 with content scaling to ensure the slides fit, and save the presentation

// as an XPS document using Aspose.Slides for .NET. The example includes basic

// file existence checks and exception handling suitable for a standalone

// console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, XPS, A4, 300DPI,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX files to XPS format with A4 page size for printing or archiving.

// - Build C# utilities that automate PowerPoint to XPS transformations.

// - Integrate XPS export functionality into .NET applications.

// - Validate presentation conversion workflows before deployment.

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

            // Input and output file paths

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

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Set slide size to A4 with content scaling to ensure fit

                presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A4Paper, Aspose.Slides.SlideSizeScaleType.EnsureFit);



                // Create XPS options (DPI setting is not applicable for XPS; using defaults)

                Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();



                // Save the presentation as XPS

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("Presentation saved as XPS to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported for saving.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URL issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

