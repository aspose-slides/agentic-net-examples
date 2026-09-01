// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPT and set JPEG quality for SWF conversion using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, configure JPEG quality

// for the generated SWF output, and save the presentation as SWF files using

// Aspose.Slides for .NET. The example illustrates the necessary steps to

// process a PPTX file, adjust image compression settings, and produce SWF

// files with different JPEG quality levels in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SWF, JPEG, JpegQuality, 

// Presentation Conversion, Image Compression, Office Automation

//

// Use Cases:

// - Convert PPTX to SWF with specific JPEG quality settings.

// - Build C# utilities for PowerPoint to SWF conversion with image quality control.

// - Automate batch processing of presentations with customized compression.

// - Validate SWF output quality in .NET applications.

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

        string outputPath1 = "output_quality80.swf";

        string outputPath2 = "output_quality50.swf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Presentation pres = new Presentation(inputPath))

            {

                // Save with JPEG quality 80

                SwfOptions options1 = new SwfOptions();

                options1.JpegQuality = 80;

                pres.Save(outputPath1, SaveFormat.Swf, options1);



                // Save with JPEG quality 50

                SwfOptions options2 = new SwfOptions();

                options2.JpegQuality = 50;

                pres.Save(outputPath2, SaveFormat.Swf, options2);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported for saving as SWF.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

