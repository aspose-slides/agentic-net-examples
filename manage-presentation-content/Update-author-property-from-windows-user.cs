// -----------------------------------------------------------------------------
// Example: Update author property from Windows user using C#
//
// Description:
// Demonstrates how to set the Author document property of a PowerPoint presentation
// to the current Windows user name using Aspose.Slides for .NET. The example loads
// an existing PPTX file, modifies the Author property, and saves the result as a new
// PPTX file. This pattern can be used in console utilities or automated workflows
// that need to ensure correct author metadata.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update Author Property, Windows User,
// Presentation Metadata, Document Properties, Automation
//
// Use Cases:
// - Automatically assign the current Windows user as the author of PPTX files.
// - Integrate author metadata updates into batch processing scripts.
// - Ensure compliance with document management policies by standardizing author info.
// - Build .NET tools that modify PowerPoint metadata before distribution.
// -----------------------------------------------------------------------------
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
