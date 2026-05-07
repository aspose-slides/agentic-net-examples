using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        int omittedHiddenSlides = GetOmittedHiddenSlides(inputPath);
        Console.WriteLine("Number of hidden slides omitted: " + omittedHiddenSlides);

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Save presentation before exit
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }

    static int GetOmittedHiddenSlides(string filePath)
    {
        try
        {
            using (Presentation pres = new Presentation(filePath))
            {
                // When ShowHiddenSlides is false (default), omitted slides equal HiddenSlides count
                return pres.DocumentProperties.HiddenSlides;
            }
        }
        catch (Exception)
        {
            // format not supported
            return 0;
        }
    }
}