using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesMemoryStreamToString
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

            // Load the presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
                return;
            }

            // Save the presentation to a memory stream
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                pres.Save(memoryStream, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported for saving
                Console.WriteLine("Saving to the specified format is not supported.");
                pres.Dispose();
                return;
            }

            // Ensure the stream position is at the beginning
            memoryStream.Position = 0;

            // Convert the memory stream content to a UTF-8 string
            string utf8String = Encoding.UTF8.GetString(memoryStream.ToArray());

            // Example: output the string length (or send it in a web service response)
            Console.WriteLine("UTF-8 string length: " + utf8String.Length);

            // Save the presentation to a file before exiting (lifecycle requirement)
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported for final save
                Console.WriteLine("Final saving format is not supported.");
            }

            // Clean up resources
            memoryStream.Close();
            pres.Dispose();
        }
    }
}