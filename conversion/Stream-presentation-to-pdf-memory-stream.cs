// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Stream presentation to PDF memory stream using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation from a file into a memory

// stream, convert it to PDF using Aspose.Slides for .NET, and write the resulting

// PDF to another memory stream. The example also shows an optional step of

// saving the PDF memory stream to a file. This pattern is useful for scenarios

// where presentations need to be processed entirely in memory, such as web

// services, cloud functions, or automated batch jobs.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, MemoryStream, Stream, 

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert PPTX files to PDF without creating intermediate files on disk.

// - Build .NET services that process presentations in-memory for performance

//   or security reasons.

// - Integrate PowerPoint to PDF conversion into automated workflows or APIs.

// - Validate presentation conversion results before further processing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Path to the source presentation file

        string inputPath = "input.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        // Load the presentation into a memory stream

        FileStream fileStream = null;

        MemoryStream inputMemoryStream = null;

        Presentation presentation = null;

        try

        {

            fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read);

            inputMemoryStream = new MemoryStream();

            fileStream.CopyTo(inputMemoryStream);

            fileStream.Close();

            inputMemoryStream.Position = 0;

            presentation = new Presentation(inputMemoryStream);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error loading presentation: " + ex.Message);

            return;

        }



        // Prepare an output memory stream for the PDF

        MemoryStream outputMemoryStream = new MemoryStream();



        // Save the presentation as PDF into the output memory stream

        try

        {

            presentation.Save(outputMemoryStream, SaveFormat.Pdf);

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error saving PDF: " + ex.Message);

        }

        finally

        {

            // Ensure resources are released

            if (presentation != null)

            {

                presentation.Dispose();

            }

            if (inputMemoryStream != null)

            {

                inputMemoryStream.Close();

            }

        }



        // Example: write the PDF memory stream to a file (optional)

        outputMemoryStream.Position = 0;

        using (FileStream pdfFileStream = new FileStream("output.pdf", FileMode.Create, FileAccess.Write))

        {

            outputMemoryStream.CopyTo(pdfFileStream);

        }

        outputMemoryStream.Close();

    }

}

