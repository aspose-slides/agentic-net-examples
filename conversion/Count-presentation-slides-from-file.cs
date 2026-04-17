using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Ensure a file path argument is provided
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a presentation file path as an argument.");
            return;
        }

        // Get the input file path
        string inputPath = args[0];

        // Verify that the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation from the specified file
            Presentation pres = new Presentation(inputPath);

            // Retrieve the total number of slides
            int slideCount = pres.Slides.Count;

            // Output the slide count
            Console.WriteLine("Number of slides: " + slideCount);

            // Save the presentation before exiting (no modifications made)
            pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
    }
}