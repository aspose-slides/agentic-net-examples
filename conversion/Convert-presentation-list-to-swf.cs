using System;
using System.IO;
using Aspose.Slides.Export;

namespace PresentationConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string listPath;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                listPath = args[0];
            }
            else
            {
                listPath = "presentations.txt";
            }

            if (!File.Exists(listPath))
            {
                Console.WriteLine("List file not found: " + listPath);
                return;
            }

            string[] lines = File.ReadAllLines(listPath);
            foreach (string line in lines)
            {
                string presentationPath = line.Trim();
                if (string.IsNullOrEmpty(presentationPath))
                {
                    continue;
                }

                if (!File.Exists(presentationPath))
                {
                    Console.WriteLine("Presentation file not found: " + presentationPath);
                    continue;
                }

                try
                {
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                    {
                        Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                        // Configure options as needed, e.g., swfOptions.ViewerIncluded = true;

                        string outputPath = Path.Combine(Path.GetDirectoryName(presentationPath), Path.GetFileNameWithoutExtension(presentationPath) + ".swf");
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                        Console.WriteLine("Converted to SWF: " + outputPath);
                    }
                }
                catch (NotSupportedException)
                {
                    // format not supported
                    Console.WriteLine("Format not supported for file: " + presentationPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + presentationPath + ": " + ex.Message);
                }
            }
        }
    }
}