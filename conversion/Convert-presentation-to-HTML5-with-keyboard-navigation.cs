// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert presentation to HTML5 with keyboard navigation using C#

//

// Description:

// Demonstrates how to convert presentation to HTML5 with keyboard navigation 

// using C# and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Presentation, Html5, 

// Keyboard, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate convert presentation to HTML5 with keyboard navigation.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Html5ConversionApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.html";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Save the presentation as HTML5.

                // Arrow key navigation is enabled by default in the generated HTML5 output.

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5);



                // Release resources

                presentation.Dispose();



                Console.WriteLine("Presentation successfully converted to HTML5.");

            }

            catch (Exception ex)

            {

                // If the format is not supported, Aspose.Slides will throw an exception.

                // Comment: format not supported

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

