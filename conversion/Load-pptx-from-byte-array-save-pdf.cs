using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation file path
        string inputFilePath = "input.pptx";
        // Output PDF file path
        string outputFilePath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation into a byte array
            byte[] presentationData = File.ReadAllBytes(inputFilePath);

            // Create a PresentationFactory and read the presentation from the byte array
            PresentationFactory factory = new PresentationFactory();
            IPresentation presentation = factory.ReadPresentation(presentationData);

            // Save the presentation as PDF
            presentation.Save(outputFilePath, SaveFormat.Pdf);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation successfully saved as PDF.");
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format exception
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}