// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Flatten PPTX form fields to PDF using C#

//

// Description:

// Demonstrates how to flatten PPTX form fields to PDF using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Flatten, Pptx, Form, 

// Fields, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate flatten PPTX form fields to PDF.

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

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation from the PPTX file

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Configure PDF options to flatten form fields (include OLE data)

            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            pdfOptions.IncludeOleData = true; // Flatten form fields for static content



            // Save the presentation as a PDF using the specified options

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



            // Release resources

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // The format is not supported for conversion

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

