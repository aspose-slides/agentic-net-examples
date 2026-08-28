// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log slide count from PPTX before conversion using C#

//

// Description:

// Demonstrates how to log the number of slides in a PPTX file before converting

// it to PDF using Aspose.Slides for .NET. The example loads a presentation,

// retrieves the slide count, outputs it to the console, and then saves the

// presentation as a PDF. This pattern helps developers validate content prior

// to conversion in automated workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Slide Count, Conversion,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Log slide count from PPTX before conversion.

// - Validate presentation content before generating PDFs.

// - Build .NET tools for PowerPoint to PDF conversion with pre‑conversion checks.

// - Automate slide count reporting in batch processing pipelines.

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

        string outputPath = "output.pdf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Presentation pres = new Presentation(inputPath))

            {

                int slideCount = pres.Slides.Count;

                Console.WriteLine("Slide count: " + slideCount);



                // Convert to PDF

                pres.Save(outputPath, SaveFormat.Pdf);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

