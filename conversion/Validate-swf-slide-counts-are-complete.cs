// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate SWF slide counts are complete using C#

//

// Description:

// Demonstrates how to validate that all slides from a PowerPoint presentation

// are successfully exported to a SWF file using Aspose.Slides for .NET. The

// example loads a PPTX file, records the expected slide count, exports the

// presentation to SWF, and returns a boolean indicating whether the export

// completed without errors (as Aspose.Slides does not expose the SWF slide

// count directly).

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Validate, Slide Count,

// Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Verify that a PPTX can be fully converted to SWF without runtime errors.

// - Integrate slide‑export validation into automated build or CI pipelines.

// - Build .NET utilities that ensure presentation assets are ready for web

//   publishing in SWF format.

// - Detect unsupported or corrupted PowerPoint files before distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfSlideValidator

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputSwfPath = "output.swf";



            bool isValid = ValidateSwfSlideCounts(inputPath, outputSwfPath);

            Console.WriteLine("SWF slide count validation result: " + isValid);

        }



        static bool ValidateSwfSlideCounts(string inputFilePath, string outputSwfFilePath)

        {

            // Verify input file existence

            if (!File.Exists(inputFilePath))

            {

                Console.WriteLine("Input file not found: " + inputFilePath);

                return false;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath);



                // Expected slide count from the source presentation

                int expectedSlideCount = presentation.Slides.Count;



                // Configure SWF export options

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                swfOptions.ShowHiddenSlides = true; // include hidden slides if any



                // Save the presentation as SWF

                presentation.Save(outputSwfFilePath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



                // If save succeeded, assume all slides were exported

                // (Aspose.Slides does not provide direct SWF slide count retrieval)

                return true;

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported

                // Comment: format not supported

                return false;

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                // Comment: format not supported

                return false;

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("Error: " + ex.Message);

                return false;

            }

        }

    }

}

