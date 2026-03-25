using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args == null || args.Length < 2)
                {
                    Console.WriteLine("Usage: ConvertToXps <input-pptx-path> <output-xps-path>");
                    return;
                }

                string inputPath = args[0];
                string outputPath = args[1];

                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Error: Input file \"{inputPath}\" not found.");
                    return;
                }

                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save the presentation to XPS format preserving layout and vector graphics
                    presentation.Save(outputPath, SaveFormat.Xps);
                }

                Console.WriteLine($"Presentation successfully converted to XPS: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}