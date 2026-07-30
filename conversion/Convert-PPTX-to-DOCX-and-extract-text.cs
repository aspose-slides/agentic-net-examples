// -----------------------------------------------------------------------------
// Example: Convert PPTX to DOCX and extract text using C#
//
// Description:
// Demonstrates how to convert a PPTX presentation to a DOCX document and
// extract the textual content using C# and Aspose.Slides for .NET together with
// Aspose.Words for .NET. The example loads a PowerPoint file, saves it as a
// Word document, then reads the generated DOCX to retrieve all text. This
// pattern can be used to automate PPTX‑to‑DOCX conversion workflows and to
// programmatically analyze presentation content.
//
// Keywords:
// C#, PowerPoint, PPTX, DOCX, Aspose.Slides for .NET, Aspose.Words for .NET,
// Convert, Extract Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of PPTX files to editable DOCX format.
// - Build tools that extract and analyze text from PowerPoint presentations.
// - Integrate presentation conversion into .NET applications or services.
// - Validate and process presentation content before publishing or further
//   transformation.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Words;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string docxPath = "output.docx";

        // Verify that the input PPTX file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save the presentation as DOCX
                presentation.Save(docxPath, SaveFormat.Docx);
            }

            // Load the generated DOCX and extract its text
            Document wordDoc = new Document(docxPath);
            string extractedText = wordDoc.GetText();

            Console.WriteLine("Extracted text from DOCX:");
            Console.WriteLine(extractedText);
        }
        catch (NotSupportedException)
        {
            // Handle the case where the requested format is not supported by Aspose.Slides
            Console.WriteLine("DOCX format is not supported by Aspose.Slides.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
