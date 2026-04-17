using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.odp";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            GifOptions gifOptions = new GifOptions(); // default settings
            presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
            presentation.Dispose();
            Console.WriteLine("Animated GIF created successfully.");
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}