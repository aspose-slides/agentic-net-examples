// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create handout PDF two slides per page using C#

//

// Description:

// Demonstrates how to create a handout PDF with two slides per page using C# 

// and Aspose.Slides for .NET. The example loads a PowerPoint presentation, 

// configures PDF export options to produce a handout layout, and saves the 

// result as a PDF file. Developers can use this pattern to automate PPTX 

// workflows, generate printable handouts, or integrate presentation processing 

// into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Handout, Slides, Page, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of handout PDFs with two slides per page.

// - Build C# tools for PowerPoint presentation processing.

// - Generate printable handouts from PPTX files in .NET applications.

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

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation pres = new Presentation(inputPath);



            // Configure PDF export options for handout with two slides per page

            PdfOptions options = new PdfOptions

            {

                ShowHiddenSlides = true,

                SlidesLayoutOptions = new HandoutLayoutingOptions

                {

                    Handout = HandoutType.Handouts2,

                    // Custom margins can be adjusted via additional properties if needed

                }

            };



            // Save the presentation as a handout PDF

            pres.Save(outputPath, SaveFormat.Pdf, options);

            pres.Dispose();



            Console.WriteLine("Handout PDF saved to " + outputPath);

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

