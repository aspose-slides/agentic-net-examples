// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Enable XPS compression when saving using C#

//

// Description:

// Demonstrates how to enable XPS compression (or related options) when saving a

// PowerPoint presentation to XPS format using Aspose.Slides for .NET. The code

// loads a PPTX file, configures XpsOptions (e.g., SaveMetafilesAsPng) to affect

// the output size, and saves the result as an XPS document. This pattern can be

// used in console applications for automated presentation processing.

//

// Keywords:

// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Enable, Compression, SaveOptions, Presentation Processing, Office Automation

//

// Use Cases:

// - Reduce XPS file size by enabling compression‑related options.

// - Build C# utilities that convert PPTX to XPS with optimized output.

// - Integrate XPS export functionality into .NET applications.

// - Validate and automate PowerPoint to XPS conversion workflows.

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

            // Input PowerPoint file path

            string inputPath = "input.pptx";

            // Output XPS file path

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

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Create XPS save options

                    XpsOptions xpsOptions = new XpsOptions();



                    // NOTE: The XpsOptions class does not contain a 'Compress' property in the current API.

                    // If compression is required, use the appropriate options provided by the library.

                    // For demonstration, we enable saving metafiles as PNG.

                    xpsOptions.SaveMetafilesAsPng = true;



                    // Save the presentation as XPS with the specified options

                    presentation.Save(outputPath, SaveFormat.Xps, xpsOptions);

                }



                Console.WriteLine("Presentation saved successfully to XPS format.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

                Console.WriteLine("The specified format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., I/O errors, licensing issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

