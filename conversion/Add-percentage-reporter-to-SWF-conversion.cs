// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add percentage reporter to SWF conversion using C#

//

// Description:

// Demonstrates how to add a percentage progress reporter to a SWF conversion 

// using C# and Aspose.Slides for .NET. The example loads a PowerPoint presentation,

// configures SWF conversion options with a custom progress callback, and saves 

// the resulting SWF file while reporting conversion progress to the console.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Percentage, Reporter, 

// Conversion, SWF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate SWF conversion with real‑time progress feedback.

// - Build C# tools for PowerPoint presentation processing that require status reporting.

// - Generate or transform PPTX files to SWF in .NET applications.

// - Monitor long‑running conversions to improve user experience.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfConversionWithProgress

{

    // Implements progress callback to report conversion progress

    public class ProgressReporter : Aspose.Slides.IProgressCallback

    {

        public void Reporting(double progressValue)

        {

            Console.WriteLine("Conversion progress: {0}%", progressValue);

        }

    }



    public class Program

    {

        public static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "LargePresentation.pptx";

            string outputPath = "LargePresentation.swf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Load the presentation and handle unsupported format

            Aspose.Slides.Presentation presentation = null;

            try

            {

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The input file format is not supported for conversion.");

                return;

            }

            catch (Exception ex)

            {

                // Handle other loading exceptions

                Console.WriteLine("Error loading presentation: " + ex.Message);

                return;

            }



            // Set up SWF conversion options with progress reporting

            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

            swfOptions.ProgressCallback = new ProgressReporter();



            // Perform the conversion and save the SWF file

            try

            {

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error during conversion: " + ex.Message);

            }

            finally

            {

                // Ensure the presentation is saved before exiting and resources are released

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }



            Console.WriteLine("Conversion completed.");

        }

    }

}

