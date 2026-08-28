// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Enable viewer UI in SWF test navigation using C#

//

// Description:

// Demonstrates how to enable viewer UI in SWF test navigation using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Enable, Viewer, Test, 

// Navigation, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate enable viewer UI in SWF test navigation.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files to SWF in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfExportExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputFileName = "input.pptx";

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

            string outputFileName = "output.swf";

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Configure SWF options with viewer UI enabled

                SwfOptions swfOptions = new SwfOptions

                {

                    ViewerIncluded = true,   // Include integrated viewer

                    ShowFullScreen = true,   // Show fullscreen button

                    ShowPageStepper = true,  // Show page stepper (navigation)

                    ShowSearch = true,       // Show search pane

                    ShowLeftPane = true,     // Show left navigation pane

                    ShowBottomPane = true    // Show bottom pane

                };



                // Save the presentation as SWF

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Dispose the presentation before exiting

                presentation.Dispose();



                Console.WriteLine("SWF file created successfully at: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format exception

                Console.WriteLine("The file format is not supported for SWF conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

