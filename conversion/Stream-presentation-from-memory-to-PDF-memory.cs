using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesMemoryStreamExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Read the PPTX file into a byte array
            byte[] pptBytes = File.ReadAllBytes(inputPath);

            // Create a memory stream from the byte array
            MemoryStream inputStream = new MemoryStream(pptBytes);

            // Initialize variables for presentation and output stream
            Presentation presentation = null;
            MemoryStream outputStream = null;

            try
            {
                // Load the presentation from the memory stream
                presentation = new Presentation(inputStream);

                // Create an output memory stream for the PDF
                outputStream = new MemoryStream();

                // Save the presentation as PDF into the output memory stream
                presentation.Save(outputStream, SaveFormat.Pdf);

                // Reset the position of the output stream for further reading if needed
                outputStream.Position = 0;

                Console.WriteLine("PDF generated in memory stream. Size: " + outputStream.Length);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            finally
            {
                // Dispose resources
                if (presentation != null)
                {
                    presentation.Dispose();
                }

                if (inputStream != null)
                {
                    inputStream.Close();
                }

                if (outputStream != null)
                {
                    outputStream.Close();
                }
            }
        }
    }
}