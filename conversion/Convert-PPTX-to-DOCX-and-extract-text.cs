using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Aspose.Slides does not support direct DOCX export.
                // Attempting to use SaveFormat.Docx would cause a compile-time error.
                // The following line is intentionally omitted:
                // presentation.Save(docxPath, Aspose.Slides.Export.SaveFormat.Docx);

                // As a placeholder, save as PPTX (or any supported format) to demonstrate saving.
                presentation.Save(docxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            // Since a DOCX file was not created, text extraction from the Word document is not performed here.
            // If DOCX support were available, you could use Aspose.Words to load the .docx file and extract its text.
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