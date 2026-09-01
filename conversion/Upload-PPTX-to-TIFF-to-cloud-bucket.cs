// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Upload PPTX to TIFF to cloud bucket using C#

//

// Description:

// Demonstrates how to convert a PowerPoint PPTX file to a multi‑page TIFF

// image using Aspose.Slides for .NET and then upload the resulting TIFF to a

// cloud storage bucket via HTTP POST. The example includes file existence

// validation, error handling for conversion and upload, and can be used as a

// template for automating presentation processing workflows in .NET.

//

// Keywords:

// C#, PowerPoint, PPTX, TIFF, Aspose.Slides for .NET, Upload, Cloud, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to TIFF for archival or preview.

// - Upload converted TIFF files to cloud storage services programmatically.

// - Build .NET tools that integrate presentation conversion with cloud APIs.

// - Validate and monitor PowerPoint processing pipelines before deployment.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Net.Http;

using System.Threading.Tasks;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static async Task Main(string[] args)

    {

        // Input PPTX file path

        string inputPath = "input.pptx";

        // Output TIFF file path

        string outputTiffPath = "output.tiff";

        // Cloud storage upload endpoint (example)

        string bucketUrl = "https://example.com/upload";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                // Save the presentation as a multi‑page TIFF image

                pres.Save(outputTiffPath, SaveFormat.Tiff);

            }

        }

        catch (NotSupportedException)

        {

            // Comment: format not supported

            Console.WriteLine("The file format is not supported for conversion.");

            return;

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error during conversion: " + ex.Message);

            return;

        }



        // Upload the generated TIFF to a cloud storage bucket

        try

        {

            using (HttpClient client = new HttpClient())

            {

                using (FileStream fileStream = new FileStream(outputTiffPath, FileMode.Open, FileAccess.Read))

                {

                    using (StreamContent content = new StreamContent(fileStream))

                    {

                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/tiff");

                        HttpResponseMessage response = await client.PostAsync(bucketUrl, content);

                        response.EnsureSuccessStatusCode();

                        Console.WriteLine("Upload successful.");

                    }

                }

            }

        }

        catch (HttpRequestException)

        {

            // Handle exception for external web service

            Console.WriteLine("Failed to upload to cloud storage.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("Unexpected error: " + ex.Message);

        }

    }

}

