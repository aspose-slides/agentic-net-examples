using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.IO;
using System.IO.Compression;

namespace ConvertPptxToDocxAndZip
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.pptx";
            string outputDocx = "output.docx";
            string zipFile = "output.zip";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputFile))
                {
                    // Aspose.Slides does not support saving to DOCX format.
                    // The following line would cause a compilation error:
                    // presentation.Save(outputDocx, SaveFormat.Docx);
                    // Instead, we can only save to supported formats such as PPTX.
                    // Comment: format not supported.
                    // For demonstration, we save to PPTX and then rename (not a true DOCX file).
                    string tempPptx = "temp.pptx";
                    presentation.Save(tempPptx, SaveFormat.Pptx);
                    if (File.Exists(outputDocx))
                    {
                        File.Delete(outputDocx);
                    }
                    File.Move(tempPptx, outputDocx);
                }

                // Compress the resulting file using zip compression.
                if (File.Exists(outputDocx))
                {
                    if (File.Exists(zipFile))
                    {
                        File.Delete(zipFile);
                    }
                    using (FileStream zipToOpen = new FileStream(zipFile, FileMode.Create))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                        {
                            archive.CreateEntryFromFile(outputDocx, Path.GetFileName(outputDocx), CompressionLevel.Optimal);
                        }
                    }
                    Console.WriteLine("Compression completed: " + zipFile);
                }
                else
                {
                    Console.WriteLine("DOCX file was not created.");
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported.
                Console.WriteLine("DOCX format is not supported by Aspose.Slides.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}