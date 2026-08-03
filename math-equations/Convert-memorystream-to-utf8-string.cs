// -----------------------------------------------------------------------------
// Example: Convert memorystream to utf8 string using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation with Aspose.Slides for .NET,
// create a MemoryStream containing UTF‑8 encoded text, convert the stream back
// to a UTF‑8 string, and finally save the presentation. The example shows the
// required presentation‑processing steps and how to work with MemoryStream data
// in a standalone console application. Developers can use this pattern to
// automate PPTX workflows, embed textual data in streams, or integrate
// presentation logic into .NET services.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, MemoryStream, UTF-8,
// String, Presentation Processing, Office Automation
//
// Use Cases:
// - Convert MemoryStream data to UTF‑8 string for web service responses.
// - Load, modify, and save PowerPoint files programmatically.
// - Embed or extract textual content using streams in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check for input file argument
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the input presentation file.");
                return;
            }

            string inputPath = args[0];
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
                return;
            }

            // Example: create a MemoryStream with UTF-8 encoded data
            byte[] sampleBytes = Encoding.UTF8.GetBytes("Sample caption text");
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(sampleBytes, 0, sampleBytes.Length);
            memoryStream.Position = 0;

            // Convert MemoryStream content to UTF-8 string
            string utf8String = Encoding.UTF8.GetString(memoryStream.ToArray());

            // Output the string (simulating inclusion in a web service response)
            Console.WriteLine("UTF-8 String from MemoryStream:");
            Console.WriteLine(utf8String);

            // Save presentation before exit
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output.pptx");
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            memoryStream.Close();
            pres.Dispose();
        }
    }
}
