using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Configure SWF options: JPEG quality 75 and disable viewer UI
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.JpegQuality = 75;
            swfOptions.ViewerIncluded = false;

            // Determine output path
            string outputDirectory = Path.GetDirectoryName(inputPath);
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".swf";
            string outputPath = Path.Combine(outputDirectory ?? string.Empty, outputFileName);

            // Save the presentation as SWF with the specified options
            try
            {
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Saving to the specified format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is saved before exit and resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}