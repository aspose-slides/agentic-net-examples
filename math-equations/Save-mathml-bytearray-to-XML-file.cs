// -----------------------------------------------------------------------------
// Example: Save MathML bytearray to XML file using C#
//
// Description:
// Demonstrates how to save a MathML byte array to an XML file using C# and 
// Aspose.Slides for .NET. The example shows the required presentation-processing 
// steps for PowerPoint files and produces the requested output in a standalone 
// console application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Save, MathML, Bytearray, File, 
// XML, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate saving MathML bytearray to an XML file.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MathMlSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output XML file path
            string outputPath = "mathml_output.xml";

            // Captured MathML as a byte array (example placeholder)
            byte[] mathMlBytes = System.Text.Encoding.UTF8.GetBytes("<math><mi>x</mi></math>");

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                // Save the MathML byte array to the file using a FileStream
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(mathMlBytes, 0, mathMlBytes.Length);
                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("IO exception occurred: " + ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
