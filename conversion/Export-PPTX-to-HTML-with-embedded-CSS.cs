// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML with embedded CSS using C#

//

// Description:

// Demonstrates how to export PPTX to HTML with embedded CSS using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Export, Pptx, Html, 

// Embedded, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export PPTX to HTML with embedded CSS.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPptxToHtml

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

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Configure HTML export options with embedded CSS (empty string for self‑contained)

                    Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

                    htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter(string.Empty, true);



                    // Save as HTML with embedded resources

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

                }



                Console.WriteLine("Presentation exported successfully to: " + outputPath);

            }

            // Handle unsupported file format exception

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            // General exception handling

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

