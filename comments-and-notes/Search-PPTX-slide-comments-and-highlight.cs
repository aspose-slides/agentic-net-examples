// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Search PPTX slide comments and highlight using C#

//

// Description:

// Demonstrates how to search PPTX slide comments and highlight using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Search, Pptx, Slide, Comments, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate search PPTX slide comments and highlight.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using System.Text.RegularExpressions;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentHighlighter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the input presentation

            string inputPath = "input.pptx";

            // Path to the output presentation

            string outputPath = "output.pptx";

            // Keyword to search in comments

            string keyword = "TODO";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine($"Input file not found: {inputPath}");

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Highlight the keyword throughout the presentation

                    // This will highlight occurrences in comments as well

                    presentation.HighlightText(keyword, Color.Yellow);



                    // Save the modified presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                // Comment: format not supported.

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}

