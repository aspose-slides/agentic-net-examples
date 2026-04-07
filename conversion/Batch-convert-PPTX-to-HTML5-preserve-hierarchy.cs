using System;
using System.IO;
using Aspose.Slides.Export;

namespace BatchConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine source and destination directories
            string sourceDir;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                sourceDir = args[0];
            }
            else
            {
                sourceDir = "InputPptx";
            }

            string destDir;
            if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
            {
                destDir = args[1];
            }
            else
            {
                destDir = "OutputHtml5";
            }

            if (!Directory.Exists(sourceDir))
            {
                Console.WriteLine("Source directory does not exist: " + sourceDir);
                return;
            }

            // Process all .pptx files recursively
            string[] pptxFiles = Directory.GetFiles(sourceDir, "*.pptx", SearchOption.AllDirectories);
            foreach (string inputPath in pptxFiles)
            {
                try
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine("File not found: " + inputPath);
                        continue;
                    }

                    // Compute relative path and output directory
                    string relativePath = Path.GetRelativePath(sourceDir, inputPath);
                    string outputSubDir = Path.Combine(destDir, Path.GetDirectoryName(relativePath));
                    if (!Directory.Exists(outputSubDir))
                    {
                        Directory.CreateDirectory(outputSubDir);
                    }

                    // Output HTML file path (same name with .html)
                    string outputHtmlPath = Path.Combine(outputSubDir, Path.GetFileNameWithoutExtension(relativePath) + ".html");

                    // Load presentation
                    using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                    {
                        // Set HTML5 options (store external resources in same folder)
                        Aspose.Slides.Export.Html5Options options = new Aspose.Slides.Export.Html5Options();
                        options.OutputPath = outputSubDir;
                        // Save as HTML5
                        pres.Save(outputHtmlPath, Aspose.Slides.Export.SaveFormat.Html5, options);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("Format not supported for file: " + inputPath);
                }
                catch (System.Net.WebException)
                {
                    // Handle external URL/web service exception
                    Console.WriteLine("Web exception occurred while processing file: " + inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file: " + inputPath);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}