// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add retry logic to SWF saving using C#

//

// Description:

// Demonstrates how to add retry logic when saving a PowerPoint presentation

// as SWF using Aspose.Slides for .NET. The example loads a PPTX file, attempts

// to convert it to SWF, and retries on transient I/O errors up to a configurable

// number of attempts. It includes handling for unsupported formats and other

// unexpected exceptions, making it suitable for robust automation scenarios.

//

// Keywords:

// C#, Aspose.Slides, SWF, PowerPoint, PPTX, retry logic, file I/O, exception handling,

// presentation conversion, .NET

//

// Use Cases:

// - Implement reliable batch conversion of PPTX files to SWF with retry on I/O failures.

// - Build .NET utilities that need resilient saving of presentations.

// - Automate PowerPoint to SWF transformation in CI/CD pipelines.

// - Handle transient file access issues during presentation processing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Threading;

using Aspose.Slides.Export;



namespace SwfConversionExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Retry parameters

            int maxAttempts = 3;

            int attempt = 0;

            bool saved = false;



            while (attempt < maxAttempts && !saved)

            {

                try

                {

                    // Load presentation

                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                    {

                        // SWF conversion options (default)

                        Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();



                        // Save as SWF

                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                    }



                    // If no exception, mark as saved

                    saved = true;

                    Console.WriteLine("Presentation saved successfully to: " + outputPath);

                }

                catch (IOException ioEx)

                {

                    // Transient file access error, retry after delay

                    attempt++;

                    Console.WriteLine("IO exception encountered (attempt " + attempt + "): " + ioEx.Message);

                    if (attempt < maxAttempts)

                    {

                        Thread.Sleep(1000); // wait 1 second before retry

                    }

                    else

                    {

                        Console.WriteLine("Maximum retry attempts reached. Conversion failed.");

                    }

                }

                catch (NotSupportedException nsEx)

                {

                    // Format not supported

                    Console.WriteLine("Format not supported: " + nsEx.Message);

                    break;

                }

                catch (Exception ex)

                {

                    // Other unexpected errors

                    Console.WriteLine("An unexpected error occurred: " + ex.Message);

                    break;

                }

            }

        }

    }

}

