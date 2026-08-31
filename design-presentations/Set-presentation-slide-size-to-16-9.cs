// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set presentation slide size to 16 9 using C#

//

// Description:

// Demonstrates how to change an existing PowerPoint presentation to a 16:9

// slide size using Aspose.Slides for .NET. The example loads a PPTX file,

// applies the OnScreen16x9 size with content scaling, and saves the result.

// This pattern can be used in console tools or automated workflows that need

// to standardize slide dimensions.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Presentation, Slide Size, 16:9,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert legacy presentations to widescreen 16:9 format.

// - Ensure consistent slide dimensions across a document library.

// - Integrate slide size adjustment into batch processing pipelines.

// - Prepare presentations for modern displays or projectors.

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

        string outputPath = "output_16x9.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the existing presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Apply a uniform 16:9 slide size and scale existing content to ensure it fits

            presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.OnScreen16x9, Aspose.Slides.SlideSizeScaleType.EnsureFit);



            // Save the modified presentation

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



            // Release resources

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

            // Format not supported comment

            // The provided file format may not be supported by Aspose.Slides.

        }

    }

}

