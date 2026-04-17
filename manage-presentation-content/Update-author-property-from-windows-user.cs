using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdateAuthorMacro
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
                    // Access document properties
                    IDocumentProperties properties = presentation.DocumentProperties;

                    // Update the Author property with the current Windows user name
                    properties.Author = Environment.UserName;

                    // Save the updated presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // The file format is not supported by Aspose.Slides
                Console.WriteLine("The format of the input file is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}