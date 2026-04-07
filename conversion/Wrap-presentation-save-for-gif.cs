using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GifConversion
{
    public static class GifConverter
    {
        public static void SavePresentationAsGif(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    GifOptions options = new GifOptions();
                    presentation.Save(destinationPath, SaveFormat.Gif, options);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for GIF conversion.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Example usage: first argument is input file, second is output file
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: GifConversion <input.pptx> <output.gif>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            GifConverter.SavePresentationAsGif(inputPath, outputPath);
        }
    }
}