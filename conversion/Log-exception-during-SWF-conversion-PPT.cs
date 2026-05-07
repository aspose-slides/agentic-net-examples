using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "corrupted.ppt";
            }

            string outputPath = Path.ChangeExtension(inputPath, ".swf");
            string logPath = "conversion.log";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            using (StreamWriter logWriter = new StreamWriter(logPath, true))
            {
                try
                {
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        SwfOptions swfOptions = new SwfOptions();
                        // Example option configuration (optional)
                        swfOptions.ViewerIncluded = true;

                        presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                        Console.WriteLine("Conversion succeeded: " + outputPath);
                    }
                }
                catch (Aspose.Slides.PptCorruptFileException ex)
                {
                    string message = $"[{DateTime.Now}] PptCorruptFileException: {ex.Message}";
                    Console.WriteLine(message);
                    logWriter.WriteLine(message);
                }
                catch (Aspose.Slides.PptUnsupportedFormatException ex)
                {
                    // Format not supported
                    string message = $"[{DateTime.Now}] PptUnsupportedFormatException: {ex.Message}";
                    Console.WriteLine(message);
                    logWriter.WriteLine(message);
                }
                catch (Exception ex)
                {
                    string message = $"[{DateTime.Now}] Unexpected exception: {ex.GetType().FullName} - {ex.Message}";
                    Console.WriteLine(message);
                    logWriter.WriteLine(message);
                }
            }
        }
    }
}