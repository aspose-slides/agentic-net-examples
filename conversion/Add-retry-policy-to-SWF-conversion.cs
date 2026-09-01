// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add retry policy to SWF conversion using C#

//

// Description:

// Demonstrates how to add a retry policy when converting a PowerPoint presentation

// to SWF format using Aspose.Slides for .NET. The example loads a PPTX file,

// attempts the conversion up to three times handling transient I/O errors,

// and reports success or failure.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Retry, Policy, Conversion,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Implement robust SWF conversion with automatic retries for I/O issues.

// - Build .NET utilities that transform PPTX files to SWF for web publishing.

// - Ensure reliable batch processing of presentations in automated workflows.

// - Diagnose and handle unsupported formats during conversion.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

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



            // Retry policy: up to three attempts for transient I/O errors

            const int maxAttempts = 3;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)

            {

                try

                {

                    // Load presentation

                    using (Presentation pres = new Presentation(inputPath))

                    {

                        // Configure SWF options if needed

                        SwfOptions swfOptions = new SwfOptions();



                        // Save as SWF

                        pres.Save(outputPath, SaveFormat.Swf, swfOptions);

                    }



                    // Conversion succeeded, exit loop

                    Console.WriteLine("Conversion succeeded on attempt " + attempt);

                    break;

                }

                catch (IOException ioEx)

                {

                    // Transient I/O error handling

                    Console.WriteLine("I/O error on attempt " + attempt + ": " + ioEx.Message);

                    if (attempt == maxAttempts)

                    {

                        Console.WriteLine("Maximum retry attempts reached. Conversion failed.");

                    }

                }

                catch (NotSupportedException nsEx)

                {

                    // Format not supported

                    Console.WriteLine("Format not supported: " + nsEx.Message);

                    // No retry for this case

                    break;

                }

                catch (Exception ex)

                {

                    // Other unexpected errors

                    Console.WriteLine("Unexpected error: " + ex.Message);

                    break;

                }

            }

        }

    }

}

