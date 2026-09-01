// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to PDF memory stream with notes using C#

//

// Description:

// Demonstrates how to load a PPTX file, convert it to a PDF document that

// includes slide notes, and write the result from a memory stream to a file

// using Aspose.Slides for .NET. The example shows configuring PDF options to

// show hidden slides and place notes at the bottom of each page.

// This pattern can be used in console applications or services that need to

// process presentations without creating intermediate files on disk.

//

// Keywords:

// C#, Aspose.Slides for .NET, PPTX, PDF, MemoryStream, Slide Notes, Convert,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint presentations to PDF while preserving speaker notes.

// - Generate PDF output in memory for further processing or transmission.

// - Build automation tools that handle PPTX files without temporary files.

// - Integrate presentation conversion into .NET backend services.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;

using Aspose.Slides;



class Program

{

    static void Main(string[] args)

    {

        // Input and output file paths

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

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Configure PDF options to include hidden slides and preserve notes layout

            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

            pdfOptions.ShowHiddenSlides = true;

            pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()

            {

                NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull

            };



            // Save the presentation to a memory stream in PDF format

            MemoryStream memoryStream = new MemoryStream();

            presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            memoryStream.Position = 0;



            // Write the memory stream to the output file

            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))

            {

                memoryStream.CopyTo(fileStream);

            }



            // Clean up resources

            memoryStream.Close();

            presentation.Dispose();



            Console.WriteLine("Conversion completed successfully.");

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

