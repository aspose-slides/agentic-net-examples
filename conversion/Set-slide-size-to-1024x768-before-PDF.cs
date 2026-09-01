// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set slide size to 1024x768 before PDF using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, change its slide size to

// 1024 × 768 points while preserving content layout, and then save the result as a

// PDF file using Aspose.Slides for .NET. The example includes basic file‑existence

// checks and exception handling suitable for a standalone console application.

// Developers can adapt this pattern to automate slide‑size adjustments prior to

// PDF conversion in their own workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Slide Size, 1024x768, 

// Presentation Processing, Office Automation, SlideSize.SetSize, EnsureFit

//

// Use Cases:

// - Ensure consistent slide dimensions before generating PDFs.

// - Build command‑line tools for batch processing of PPTX files.

// - Integrate slide‑size normalization into document conversion pipelines.

// - Validate and adjust presentation layouts programmatically.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Change slide dimensions to 1024 × 768 points, ensuring content fits

            presentation.SlideSize.SetSize(1024f, 768f, Aspose.Slides.SlideSizeScaleType.EnsureFit);



            // Save the presentation as PDF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

