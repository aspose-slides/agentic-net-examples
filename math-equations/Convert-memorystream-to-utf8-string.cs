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