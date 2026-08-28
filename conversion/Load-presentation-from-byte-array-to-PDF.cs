// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation from byte array to PDF using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation from a byte array and

// convert it to PDF using C# and Aspose.Slides for .NET. The example reads a

// PPTX file into memory, creates a Presentation object from the byte array,

// and saves the result as a PDF file in a standalone console application.

// This pattern can be used to automate PPTX processing, integrate presentation

// conversion into services, or validate presentation content before publishing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Load, Presentation, Byte,

// Array, Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert PowerPoint files to PDF when the source is available as a byte array.

// - Build .NET tools that process presentations in memory without temporary files.

// - Integrate PPTX to PDF conversion into web services or background jobs.

// - Validate and transform presentation data programmatically before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input presentation file path (to be read into a byte array)

        string inputPath = "input.pptx";

        // Output PDF file path

        string outputPath = "output.pdf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation file into a byte array

            byte[] presentationData = File.ReadAllBytes(inputPath);



            // Create a memory stream from the byte array

            using (MemoryStream presentationStream = new MemoryStream(presentationData))

            {

                // Load the presentation from the memory stream

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationStream))

                {

                    // Save the presentation as PDF

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

                }

            }

        }

        catch (NotSupportedException)

        {

            // Comment: format not supported

            Console.WriteLine("The presentation format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

