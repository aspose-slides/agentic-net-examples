// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to HTML5 with brand CSS using C#

//

// Description:

// Demonstrates how to convert PPTX to HTML5 with brand CSS using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Html5, Brand, CSS, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate convert PPTX to HTML5 with brand CSS.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationToHtml5

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output paths

            string inputPath = "input.pptx";

            string outputHtml = "output.html";

            string outputResourcesDir = "output_resources";



            // Custom CSS for corporate branding

            string customCss = "body { background-color:#f0f0f0; } .slide { border:1px solid #ccc; }";



            // Override paths from command line arguments if provided

            if (args.Length >= 2)

            {

                inputPath = args[0];

                outputHtml = args[1];

            }



            // Check if input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Ensure output resources directory exists

                if (!Directory.Exists(outputResourcesDir))

                {

                    Directory.CreateDirectory(outputResourcesDir);

                }



                // Set HTML5 export options

                Html5Options html5Options = new Html5Options();

                html5Options.EmbedImages = true; // Embed images into HTML

                html5Options.OutputPath = outputResourcesDir; // Store external resources here



                // Save as HTML5

                presentation.Save(outputHtml, SaveFormat.Html5, html5Options);

                presentation.Dispose();



                // Inject custom CSS into the generated HTML file

                if (File.Exists(outputHtml))

                {

                    string htmlContent = File.ReadAllText(outputHtml);

                    string headTag = "<head>";

                    int headIndex = htmlContent.IndexOf(headTag, StringComparison.OrdinalIgnoreCase);

                    if (headIndex != -1)

                    {

                        int insertPos = headIndex + headTag.Length;

                        string styleTag = "\n<style>\n" + customCss + "\n</style>\n";

                        htmlContent = htmlContent.Insert(insertPos, styleTag);

                        File.WriteAllText(outputHtml, htmlContent);

                    }

                }

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                // Format not supported

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

