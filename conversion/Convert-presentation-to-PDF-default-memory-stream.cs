// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert presentation to PDF default memory stream using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to a PDF document

// using a MemoryStream with default save options. The example loads a PPTX

// file, saves it to a PDF format directly into a MemoryStream, and shows how

// to reset the stream for further processing. This pattern is useful for

// scenarios where the PDF output needs to be kept in memory rather than

// written to disk.

//

// Keywords:

// C#, Aspose.Slides for .NET, PDF conversion, MemoryStream, PowerPoint, PPTX,

// Presentation to PDF, In-memory processing, Office Automation

//

// Use Cases:

// - Convert PPTX files to PDF without creating intermediate files.

// - Process PDF data in-memory for web services or APIs.

// - Integrate PDF conversion into .NET applications that require stream handling.

// - Perform post-conversion operations such as uploading or further analysis.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            using (MemoryStream memoryStream = new MemoryStream())

            {

                // Save presentation to PDF in memory stream using default options

                presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pdf);

                // The memoryStream now contains the PDF data for further processing

                memoryStream.Position = 0;

                // Further processing can be performed here

            }

            // Ensure presentation resources are released

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

