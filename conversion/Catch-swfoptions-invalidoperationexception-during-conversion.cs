// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Catch SwfOptions InvalidOperationException during conversion using C#

//

// Description:

// Demonstrates how to catch an InvalidOperationException thrown when

// configuring unsupported SwfOptions during conversion of a PowerPoint

// presentation to SWF using Aspose.Slides for .NET. The example loads a PPTX

// file, attempts to save it as SWF with custom options, and handles specific

// exceptions that may arise.

//

// Keywords:

// C#, Aspose.Slides, SWF, InvalidOperationException, Presentation conversion,

// PowerPoint, PPTX, Exception handling, Office Automation

//

// Use Cases:

// - Detect and handle unsupported SWF conversion options.

// - Build robust .NET tools for converting PPTX files to SWF.

// - Implement detailed error handling for presentation processing workflows.

// - Ensure graceful fallback when conversion features are not available.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine input file path

        var inputPath = args.Length > 0 ? args[0] : "input.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            var presentation = new Aspose.Slides.Presentation(inputPath);

            try

            {

                // Configure SWF conversion options

                var swfOptions = new Aspose.Slides.Export.SwfOptions();

                // Example of an unsupported feature that may trigger InvalidOperationException

                // swfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions();



                // Define output path

                var outputPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", "output.swf");



                // Attempt to save as SWF with the specified options

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                Console.WriteLine("Presentation successfully saved as SWF.");

            }

            finally

            {

                // Ensure the presentation is disposed before exiting

                presentation.Dispose();

            }

        }

        catch (InvalidOperationException)

        {

            // Handle unsupported features requested for SWF conversion

            Console.WriteLine("Unsupported feature requested for SWF conversion.");

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("PPTX format not supported.");

        }

        catch (Aspose.Slides.PptUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("PPT format not supported.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

