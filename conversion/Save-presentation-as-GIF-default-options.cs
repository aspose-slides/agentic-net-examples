using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

public static class GifConverter
{
    // Wraps Presentation.Save for GIF conversion with default options
    public static void ConvertToGif(string inputPath, string outputPath)
    {
        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            // Use default GIF options
            Aspose.Slides.Export.GifOptions options = new Aspose.Slides.Export.GifOptions();
            // Save as GIF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, options);
            // Dispose the presentation
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        GifConverter.ConvertToGif(inputPath, outputPath);
    }
}