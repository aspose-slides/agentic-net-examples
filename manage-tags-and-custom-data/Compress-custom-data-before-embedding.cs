// -----------------------------------------------------------------------------
// Example: Compress custom data before embedding using C#
//
// Description:
// Demonstrates how to compress a custom data payload using GZip before embedding
// it into a PowerPoint presentation with Aspose.Slides for .NET. The example
// loads an existing PPTX file, prepares a UTF‑8 text payload, compresses it,
// and outlines where the compressed data should be added to the presentation's
// custom data collection. Finally, it saves the modified presentation.
// This pattern helps developers automate PPTX workflows that require
// embedding compressed custom data.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Custom, Data, Embedding,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate compression of custom data before embedding into PPTX files.
// - Build C# tools for PowerPoint presentation processing with embedded resources.
// - Generate or transform PPTX files in .NET applications while reducing payload size.
// - Validate presentation workflows that involve custom data integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompressionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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
                    // Prepare custom data payload
                    string customText = "This is a custom data payload that will be compressed before embedding.";
                    byte[] payloadBytes = Encoding.UTF8.GetBytes(customText);

                    // Compress the payload using GZip
                    byte[] compressedData;
                    using (MemoryStream compressedStream = new MemoryStream())
                    {
                        using (GZipStream gzip = new GZipStream(compressedStream, CompressionMode.Compress, true))
                        {
                            gzip.Write(payloadBytes, 0, payloadBytes.Length);
                        }
                        compressedData = compressedStream.ToArray();
                    }

                    // Embed the compressed custom data into the presentation
                    // Note: The actual method to add custom data may vary; this is a placeholder for the appropriate API.
                    // For example, you might use presentation.CustomData.AddCustomXmlPart("CustomPayload", compressedData);
                    // Assuming such a method exists:
                    // presentation.CustomData.AddCustomXmlPart("CustomPayload", compressedData);
                    // Placeholder comment for embedding logic:
                    // TODO: Embed compressedData into the presentation's custom data collection.

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
