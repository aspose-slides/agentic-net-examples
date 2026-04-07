using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirectory;
            if (args.Length > 0)
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }

            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            string[] presentationFiles = Directory.GetFiles(inputDirectory, "*.pptx");
            foreach (string presentationPath in presentationFiles)
            {
                if (!File.Exists(presentationPath))
                {
                    Console.WriteLine("File not found: " + presentationPath);
                    continue;
                }

                try
                {
                    using (Presentation pres = new Presentation(presentationPath))
                    {
                        string presentationTitle = Path.GetFileNameWithoutExtension(presentationPath);
                        string outputFolder = Path.Combine(inputDirectory, presentationTitle);
                        if (!Directory.Exists(outputFolder))
                        {
                            Directory.CreateDirectory(outputFolder);
                        }

                        for (int i = 0; i < pres.Slides.Count; i++)
                        {
                            ISlide slide = pres.Slides[i];
                            string slideFileName = Path.Combine(outputFolder, $"Slide_{i + 1}.png");
                            using (IImage image = slide.GetImage())
                            {
                                image.Save(slideFileName, Aspose.Slides.ImageFormat.Png);
                            }
                        }

                        // Save presentation before exit (even if unchanged)
                        pres.Save(presentationPath, SaveFormat.Pptx);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + presentationPath + ": " + ex.Message);
                }
            }
        }
    }
}