using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Access document properties
                IDocumentProperties properties = presentation.DocumentProperties;

                // Modify string properties
                properties.Author = "John Doe";
                properties.Title = "Updated Presentation Title";
                properties.Subject = "Demo Subject";

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();

                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}