// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Retry conversion five times on transient errors using C#

//

// Description:

// Demonstrates how to retry conversion five times on transient I/O errors 

// using C# and Aspose.Slides for .NET. The example loads a PowerPoint file, 

// attempts to save it, and retries the operation up to five times when a 

// transient IOException occurs. This pattern helps automate PPTX workflows 

// that may encounter temporary file system or network issues.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Retry, Conversion, Five, Times, 

// Transient Errors, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate retry conversion five times on transient I/O errors.

// - Build C# tools for resilient PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications with error handling.

// - Validate presentation workflows before publishing or integration.

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

        string outputPath = "output.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        // Retry loop for transient network/I/O errors

        int maxAttempts = 5;

        int attempt = 0;

        bool success = false;



        while (attempt < maxAttempts && !success)

        {

            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Save the presentation in the desired format

                    pres.Save(outputPath, SaveFormat.Pptx);

                }



                success = true;

                Console.WriteLine("Conversion succeeded.");

            }

            catch (IOException ioEx)

            {

                // Handle transient I/O errors

                attempt++;

                Console.WriteLine($"Transient I/O error on attempt {attempt}: {ioEx.Message}");

                if (attempt >= maxAttempts)

                {

                    Console.WriteLine("Maximum retry attempts reached. Conversion failed.");

                }

                else

                {

                    // Wait before retrying

                    System.Threading.Thread.Sleep(1000);

                }

            }

            catch (NotSupportedException nsEx)

            {

                // Handle unsupported format errors

                Console.WriteLine("Format not supported: " + nsEx.Message);

                break;

            }

            catch (Exception ex)

            {

                // Handle any other unexpected errors

                Console.WriteLine("Unexpected error: " + ex.Message);

                break;

            }

        }

    }

}

