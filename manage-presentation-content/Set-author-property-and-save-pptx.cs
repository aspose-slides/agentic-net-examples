using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdatePresentationAuthor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string newAuthor = "John Doe";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Update the Author property
                IDocumentProperties properties = presentation.DocumentProperties;
                properties.Author = newAuthor;

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation author updated and saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported file formats if needed
            }
        }
    }
}