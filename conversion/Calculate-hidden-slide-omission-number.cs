using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the number of hidden slides omitted when ShowHiddenSlides is false
            int omittedHiddenSlides = GetOmittedHiddenSlides(presentation);
            Console.WriteLine("Number of hidden slides omitted: " + omittedHiddenSlides);

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    // Returns the number of hidden slides omitted when ShowHiddenSlides is false
    static int GetOmittedHiddenSlides(Aspose.Slides.Presentation pres)
    {
        // ShowHiddenSlides defaults to false, so omitted slides equal the hidden slides count
        return pres.DocumentProperties.HiddenSlides;
    }
}