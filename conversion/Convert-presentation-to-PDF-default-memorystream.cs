using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main(string[] args)
    {
        // Path to the input presentation
        string inputPath = "sample.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation from the file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create a memory stream to hold the PDF output
            MemoryStream memoryStream = new MemoryStream();

            // Save the presentation to the memory stream in PDF format using default options
            presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pdf);

            // The memoryStream now contains the PDF data and can be processed further
            memoryStream.Position = 0;
            // TODO: Add further processing of the PDF data here

            // Close the stream and dispose the presentation as required by lifecycle rules
            memoryStream.Close();
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // The format is not supported for conversion
            Console.WriteLine("The presentation format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}