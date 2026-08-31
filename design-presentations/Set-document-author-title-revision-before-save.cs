// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set document author title revision before save using C#

//

// Description:

// Demonstrates how to set the document author, title, and revision number

// before saving a PowerPoint presentation using C# and Aspose.Slides for .NET.

// The example loads an existing PPTX file, updates its built‑in document

// properties, and saves the modified file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Document Properties, Author,

// Title, Revision, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting document metadata (author, title, revision) before saving.

// - Build C# utilities for PowerPoint presentation metadata management.

// - Integrate metadata updates into .NET applications handling PPTX files.

// - Ensure consistent document properties across generated or modified presentations.

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

        string outputPath = "output.pptx";



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



            // Access built-in document properties

            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            documentProperties.Author = "John Doe";

            documentProperties.Title = "Sample Presentation";

            documentProperties.RevisionNumber = 2;



            // Save the updated presentation

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle exceptions (e.g., unsupported format)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

