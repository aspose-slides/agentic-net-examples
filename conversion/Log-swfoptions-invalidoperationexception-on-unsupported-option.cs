// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log SwfOptions InvalidOperationException on unsupported option using C#

//

// Description:

// Demonstrates how to log an InvalidOperationException when setting an unsupported

// SlidesLayoutOptions value in SwfOptions while converting a PPTX presentation to

// SWF using Aspose.Slides for .NET. The example includes loading a presentation,

// configuring SWF export options, handling the exception, and saving the output.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SwfOptions, InvalidOperationException,

// Unsupported Option, Presentation Processing, Office Automation

//

// Use Cases:

// - Detect and log unsupported SWF export options during conversion.

// - Build C# utilities for PowerPoint to SWF conversion with robust error handling.

// - Automate validation of presentation export settings in .NET applications.

// - Ensure reliable workflow when integrating Aspose.Slides into larger systems.

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

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");



            // Check if input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Create SWF options

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.ViewerIncluded = true;



                try

                {

                    // Attempt to set an unsupported SlidesLayoutOptions value

                    // This should throw InvalidOperationException

                    swfOptions.SlidesLayoutOptions = new HandoutLayoutingOptions();

                }

                catch (InvalidOperationException ex)

                {

                    // Log the exception when an unsupported option is set

                    Console.WriteLine("InvalidOperationException caught: " + ex.Message);

                }



                // Save the presentation as SWF

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Save presentation before exit (already saved)

            }

            catch (PptUnsupportedFormatException)

            {

                // Format not supported

                // Comment: format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported

                // Comment: format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

