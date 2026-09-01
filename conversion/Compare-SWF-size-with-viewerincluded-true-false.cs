// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare SWF size with viewerincluded true false using C#

//

// Description:

// Demonstrates how to compare the file size of SWF outputs generated with

// ViewerIncluded set to true and false using C# and Aspose.Slides for .NET.

// The example loads a PPTX presentation, saves it twice as SWF (with and

// without the embedded viewer), and prints the resulting file sizes.

// This pattern helps developers automate size comparisons, validate output

// differences, or integrate SWF generation into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compare, Size, ViewerIncluded,

// SWF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate comparison of SWF file sizes with ViewerIncluded true/false.

// - Build C# tools for PowerPoint presentation processing and SWF generation.

// - Generate SWF files with or without the embedded viewer for distribution.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input PPTX file path

        string inputPath = "input.pptx";

        // Output SWF file paths for different ViewerIncluded settings

        string outputPathViewerFalse = "output_false.swf";

        string outputPathViewerTrue = "output_true.swf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Save SWF without viewer

                Aspose.Slides.Export.SwfOptions optionsFalse = new Aspose.Slides.Export.SwfOptions();

                optionsFalse.ViewerIncluded = false;

                presentation.Save(outputPathViewerFalse, Aspose.Slides.Export.SaveFormat.Swf, optionsFalse);



                // Save SWF with viewer

                Aspose.Slides.Export.SwfOptions optionsTrue = new Aspose.Slides.Export.SwfOptions();

                optionsTrue.ViewerIncluded = true;

                presentation.Save(outputPathViewerTrue, Aspose.Slides.Export.SaveFormat.Swf, optionsTrue);

            }



            // Retrieve file sizes

            long sizeFalse = new FileInfo(outputPathViewerFalse).Length;

            long sizeTrue = new FileInfo(outputPathViewerTrue).Length;



            // Output the comparison results

            Console.WriteLine("SWF size (ViewerIncluded = false): " + sizeFalse + " bytes");

            Console.WriteLine("SWF size (ViewerIncluded = true): " + sizeTrue + " bytes");

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URLs or web services)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

