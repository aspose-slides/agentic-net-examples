using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save presentation to PDF in memory stream using default options
                presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pdf);
                // The memoryStream now contains the PDF data for further processing
                memoryStream.Position = 0;
                // Further processing can be performed here
            }
            // Ensure presentation resources are released
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}