// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX 3D HTML5 WebGL using C#

//

// Description:

// Demonstrates how to export a PPTX file containing 3D content to an HTML5

// WebGL representation using C# and Aspose.Slides for .NET. The example shows

// the required presentation-processing steps for PowerPoint files and

// produces the requested output in a standalone console application. Developers

// can use this pattern to automate PPTX workflows, validate results, or integrate

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Html5, WebGL, 3D, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPTX 3D presentations to HTML5 WebGL.

// - Build C# tools for PowerPoint presentation processing with 3D content.

// - Generate or transform PPTX files in .NET applications while preserving 3D models.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Html5ExportExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output paths

            string inputPath = "input.pptx";

            string outputDirectory = "output";

            string outputHtmlPath = Path.Combine(outputDirectory, "presentation.html");



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output directory exists

            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Configure HTML5 export options

                Html5Options html5Options = new Html5Options()

                {

                    // Embed images into the HTML file

                    EmbedImages = true,

                    // Specify where external resources (e.g., 3D model files) should be stored

                    OutputPath = outputDirectory,

                    // Note: Aspose.Slides renders 3D models using WebGL automatically when exporting to HTML5

                };



                // Save as HTML5

                presentation.Save(outputHtmlPath, SaveFormat.Html5, html5Options);



                // Dispose presentation

                presentation.Dispose();



                Console.WriteLine("Presentation exported successfully to: " + outputHtmlPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URL issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

