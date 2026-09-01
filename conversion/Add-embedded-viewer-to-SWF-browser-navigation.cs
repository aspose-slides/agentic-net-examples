// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add embedded viewer to SWF browser navigation using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to an SWF file with

// an integrated viewer UI (navigation panes, fullscreen button, etc.) using

// Aspose.Slides for .NET. The example loads a PPTX file, configures viewer

// options, saves the result as SWF, and outlines how to test navigation

// functionality in browsers.

//

// Keywords:

// C#, Aspose.Slides, SWF, Embedded Viewer, Browser Navigation, PowerPoint,

// PPTX, Presentation Conversion, Office Automation

//

// Use Cases:

// - Generate SWF files with built‑in navigation controls for web publishing.

// - Automate PowerPoint to SWF conversion with viewer UI in .NET applications.

// - Validate SWF navigation buttons across different browsers.

// - Integrate presentation conversion into custom C# tools or services.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfConversionExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");



            // Check if the input file exists

            if (!File.Exists(inputFilePath))

            {

                Console.WriteLine("Input file does not exist: " + inputFilePath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputFilePath);



                // Configure SWF options with viewer UI enabled

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.ViewerIncluded = true; // Include integrated viewer

                swfOptions.ShowFullScreen = true; // Show fullscreen button

                swfOptions.ShowBottomPane = true; // Show bottom pane

                swfOptions.ShowLeftPane = true;   // Show left pane

                swfOptions.ShowTopPane = true;    // Show top pane



                // Save the presentation as SWF

                presentation.Save(outputFilePath, SaveFormat.Swf, swfOptions);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("SWF file generated successfully: " + outputFilePath);



                // Placeholder: Evaluate navigation button functionality across browsers

                // This would involve loading the generated SWF in different browsers and

                // verifying that navigation buttons (next/previous) work as expected.

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided file format is not supported for conversion.

                Console.WriteLine("The file format is not supported for SWF conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URL issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

