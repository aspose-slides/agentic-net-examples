using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputFile))
                {
                    // Access document properties
                    IDocumentProperties docProps = presentation.DocumentProperties;

                    // Check for mandatory custom property "ProjectCode"
                    bool hasProjectCode = docProps.ContainsCustomProperty("ProjectCode");
                    if (!hasProjectCode)
                    {
                        Console.WriteLine("Mandatory custom property 'ProjectCode' is missing. Presentation will not be saved.");
                        return;
                    }

                    // Save the presentation
                    presentation.Save(outputFile, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues, Aspose.Slides exceptions)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}