// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert ODP to PDF 1024x768 using C#

//

// Description:

// Demonstrates how to batch convert all ODP files in a folder to PDF with a

// slide size of 1024x768 using C# and Aspose.Slides for .NET. The program

// loads each ODP presentation, sets the slide dimensions, and saves it as a

// PDF file in an output folder. This pattern can be used to automate

// presentation conversion workflows.

//

// Keywords:

// C#, ODP, PDF, Aspose.Slides for .NET, Batch, Convert, 1024X768, Presentation

// Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of ODP presentations to PDF with specific

//   dimensions.

// - Build command‑line tools for PowerPoint/ODP processing in .NET.

// - Integrate ODP to PDF conversion into larger document‑management systems.

// - Validate and standardize slide sizes before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input directory: first argument or current directory

        string inputDir = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();



        // Output directory for PDFs

        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");

        if (!Directory.Exists(outputDir))

            Directory.CreateDirectory(outputDir);



        // Get all ODP files in the input directory

        string[] odpFiles = Directory.GetFiles(inputDir, "*.odp");

        foreach (string odpPath in odpFiles)

        {

            // Verify the file exists

            if (!File.Exists(odpPath))

                continue;



            try

            {

                // Load the ODP presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(odpPath);



                // Set custom slide dimensions: 1024 x 768 points

                presentation.SlideSize.SetSize(1024f, 768f, Aspose.Slides.SlideSizeScaleType.EnsureFit);



                // Determine output PDF path

                string pdfFileName = Path.GetFileNameWithoutExtension(odpPath) + ".pdf";

                string pdfPath = Path.Combine(outputDir, pdfFileName);



                // Save the presentation as PDF

                presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);



                // Release resources

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported – skip this file

            }

            catch (Exception ex)

            {

                // Log unexpected errors and continue

                Console.WriteLine("Error processing file: " + odpPath);

                Console.WriteLine(ex.Message);

            }

        }

    }

}

