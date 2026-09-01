// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set GIF loop infinite high quality using C#

//

// Description:

// Demonstrates how to attempt setting an infinite loop and high quality for a GIF

// using C# and Aspose.Slides for .NET. The example loads a PPTX file, creates a

// GifOptions instance, and saves the presentation as a GIF. It also documents the

// current limitation that loop count and quality settings are not exposed in the

// API, providing developers with guidance on what is currently supported.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, GIF, Loop, Infinite, High Quality,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to GIF format in .NET applications.

// - Understand API limitations regarding GIF loop count and quality settings.

// - Build C# tools for PowerPoint presentation processing and validation.

// - Automate presentation workflows that involve GIF output.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace GifConversionExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.gif";



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



                // Create custom GifOptions

                GifOptions gifOptions = new GifOptions();



                // NOTE: Loop count and quality level are not exposed in the current GifOptions API.

                // These settings are not supported; therefore they cannot be set programmatically.



                // Save the presentation as GIF using the custom options

                presentation.Save(outputPath, SaveFormat.Gif, gifOptions);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation successfully saved as GIF: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format exception

                // Format not supported

                Console.WriteLine("The requested format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

