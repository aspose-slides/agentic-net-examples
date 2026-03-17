using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Path to the source PPTX file
            string sourcePath = "source.pptx";

            // Load the presentation
            Presentation presentation = new Presentation(sourcePath);

            // Path for the output PPTX file
            string outputPath = "output.pptx";

            // Save the presentation using the correct SaveFormat enumeration
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}