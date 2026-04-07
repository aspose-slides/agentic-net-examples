using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchExportPptToOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories relative to the current working directory
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "InputPpt");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "OutputOdp");

            // Verify that the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all PPT and PPTX files in the input directory
            string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt*");

            foreach (string pptFilePath in pptFiles)
            {
                // Verify that the file exists before processing
                if (!File.Exists(pptFilePath))
                {
                    Console.WriteLine("File not found: " + pptFilePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptFilePath))
                    {
                        // Build the output ODP file path
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptFilePath);
                        string odpFilePath = Path.Combine(outputDir, fileNameWithoutExt + ".odp");

                        // Save the presentation as ODP
                        presentation.Save(odpFilePath, Aspose.Slides.Export.SaveFormat.Odp);
                        Console.WriteLine("Converted: " + pptFilePath + " -> " + odpFilePath);
                    }
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Handle unsupported input formats
                    Console.WriteLine("Unsupported format for file: " + pptFilePath);
                }
                catch (DirectoryNotFoundException ex)
                {
                    // Handle missing directories during save
                    Console.WriteLine("Directory not found: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General error handling
                    Console.WriteLine("Error processing file " + pptFilePath + ": " + ex.Message);
                }
            }
        }
    }
}