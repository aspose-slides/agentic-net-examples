// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Split PPT into individual HTML files using C#

//

// Description:

// Demonstrates how to split a PowerPoint presentation into individual HTML files

// using C# and Aspose.Slides for .NET. The example loads a PPTX file, creates an

// output directory, exports each slide as a separate HTML file, and finally

// saves a copy of the original presentation. This pattern can be used to

// automate PPTX workflows, validate results, or integrate presentation logic into

// .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, HTML, Split, Individual,

// Html, Files, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate split PPT into individual HTML files.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Path to the source presentation

        string inputPath = "input.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Create output directory for HTML files

                string outputDir = Path.Combine(Environment.CurrentDirectory, "HtmlSlides");

                if (!Directory.Exists(outputDir))

                {

                    Directory.CreateDirectory(outputDir);

                }



                // Export each slide to a separate HTML file

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.html");

                    int[] slideIndices = new int[] { i + 1 };

                    presentation.Save(outputPath, slideIndices, SaveFormat.Html);

                }



                // Save the original presentation before exiting

                string savedPresPath = Path.Combine(outputDir, "original_saved.pptx");

                presentation.Save(savedPresPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

