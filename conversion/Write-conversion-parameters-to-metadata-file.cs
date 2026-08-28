// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Write conversion parameters to metadata file using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to SWF using Aspose.Slides for .NET,

// configure conversion options, and write those parameters to a separate metadata text file.

// The example includes loading a PPTX, setting SWF options such as compression and viewer

// inclusion, saving the SWF output, and persisting the chosen settings for later reference.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Write, Conversion, Parameters, 

// Metadata, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to SWF with specific options.

// - Record conversion settings in a metadata file for auditing or reproducibility.

// - Build C# utilities for batch processing of presentations.

// - Integrate conversion workflows into .NET applications with traceable parameters.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfConversionWithMetadata

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputSwfPath = "output.swf";

            string metadataPath = "output.meta.txt";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Configure SWF conversion options

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.Compressed = true;               // compress SWF

                swfOptions.ShowHiddenSlides = false;        // do not include hidden slides

                swfOptions.ViewerIncluded = true;           // include viewer

                swfOptions.EnableContextMenu = true;        // enable context menu



                // Save as SWF

                presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);



                // Write conversion parameters to metadata file

                using (StreamWriter writer = new StreamWriter(metadataPath))

                {

                    writer.WriteLine("Compressed=" + swfOptions.Compressed);

                    writer.WriteLine("ShowHiddenSlides=" + swfOptions.ShowHiddenSlides);

                    writer.WriteLine("ViewerIncluded=" + swfOptions.ViewerIncluded);

                    writer.WriteLine("EnableContextMenu=" + swfOptions.EnableContextMenu);

                }



                // Dispose presentation

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

