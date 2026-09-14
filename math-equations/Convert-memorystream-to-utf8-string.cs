// -----------------------------------------------------------------------------
// Example: Convert PowerPoint Presentation to UTF-8 String via MemoryStream using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, saves it into a MemoryStream using
// Aspose.Slides for .NET, and converts the binary stream content to a UTF‑8 string.
// The resulting string can be used as a payload in a web service response or
// for debugging purposes. The code checks for file existence and handles
// exceptions related to loading, saving, and conversion.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MemoryStream, UTF-8, web service response
//
// Use Cases:
// - Embed a PowerPoint presentation binary in a JSON API response.
// - Provide a string representation of a PPTX for logging or debugging.
// - Convert presentation data to UTF‑8 for transmission over text‑based protocols.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;

namespace AsposeSlidesMemoryStreamExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "example.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Save the presentation to a MemoryStream in PPTX format
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation to stream: " + ex.Message);
                presentation.Dispose();
                return;
            }

            // Convert the MemoryStream content to a UTF-8 string
            string utf8String = null;
            try
            {
                memoryStream.Position = 0;
                byte[] bytes = memoryStream.ToArray();
                utf8String = Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to convert stream to UTF-8 string: " + ex.Message);
            }

            // Simulate a web service response by outputting the string length and a preview
            if (utf8String != null)
            {
                Console.WriteLine("UTF-8 string length: " + utf8String.Length);
                Console.WriteLine("String preview (first 200 characters):");
                Console.WriteLine(utf8String.Substring(0, Math.Min(200, utf8String.Length)));
            }
            else
            {
                Console.WriteLine("UTF-8 string conversion resulted in null.");
            }

            // Clean up resources
            memoryStream.Close();
            presentation.Dispose();
        }
    }
}
