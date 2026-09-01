// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add progress bar to TIFF conversion using C#

//

// Description:

// Demonstrates how to add a progress bar while converting a PowerPoint presentation

// to a multi‑page TIFF image using C# and Aspose.Slides for .NET. The example loads a

// PPTX file, configures TiffOptions with a custom IProgressCallback implementation,

// and saves the presentation as a TIFF while reporting progress to the console.

//

// Keywords:

// C#, PowerPoint, PPTX, TIFF, Aspose.Slides for .NET, Progress Bar, Conversion,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Show conversion progress for large PPTX to TIFF transformations.

// - Build console utilities that provide user feedback during file processing.

// - Integrate progress reporting into .NET applications that handle slide exports.

// - Automate batch conversion of presentations with real‑time status updates.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesTiffConversion

{

    // Implements IProgressCallback to receive progress updates during saving

    public class ConsoleProgressCallback : IProgressCallback

    {

        // Reporting method required by IProgressCallback

        public void Reporting(double progressValue)

        {

            // Write progress percentage on the same line

            Console.Write("\rProgress: {0:0.##}%", progressValue);

            // When progress reaches 100%, move to next line

            if (progressValue >= 100.0)

            {

                Console.WriteLine();

            }

        }

    }



    public class Program

    {

        public static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.tiff";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Configure TIFF options with progress callback

                    TiffOptions tiffOptions = new TiffOptions();

                    tiffOptions.ProgressCallback = new ConsoleProgressCallback();



                    // Save the presentation as a multi‑page TIFF

                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                }



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (PptxUnsupportedFormatException ex)

            {

                // Handle unsupported format for PPTX files

                Console.WriteLine("Unsupported PPTX format: " + ex.Message);

            }

            catch (PptUnsupportedFormatException ex)

            {

                // Handle unsupported format for PPT files

                Console.WriteLine("Unsupported PPT format: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., I/O errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

