using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation file
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation into a memory stream
        FileStream fileStream = null;
        MemoryStream inputMemoryStream = null;
        Presentation presentation = null;
        try
        {
            fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            inputMemoryStream = new MemoryStream();
            fileStream.CopyTo(inputMemoryStream);
            fileStream.Close();
            inputMemoryStream.Position = 0;
            presentation = new Presentation(inputMemoryStream);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Prepare an output memory stream for the PDF
        MemoryStream outputMemoryStream = new MemoryStream();

        // Save the presentation as PDF into the output memory stream
        try
        {
            presentation.Save(outputMemoryStream, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving PDF: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (presentation != null)
            {
                presentation.Dispose();
            }
            if (inputMemoryStream != null)
            {
                inputMemoryStream.Close();
            }
        }

        // Example: write the PDF memory stream to a file (optional)
        outputMemoryStream.Position = 0;
        FileStream pdfFileStream = new FileStream("output.pdf", FileMode.Create, FileAccess.Write);
        outputMemoryStream.CopyTo(pdfFileStream);
        pdfFileStream.Close();
        outputMemoryStream.Close();
    }
}