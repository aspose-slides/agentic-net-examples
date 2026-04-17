using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchMasterBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the folder containing PPTX files
            string inputFolder = @"C:\Presentations";

            // Verify the folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Get all PPTX files in the folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");

            foreach (string filePath in pptxFiles)
            {
                // Verify the file exists (should always be true here)
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(filePath))
                    {
                        // Iterate through all master slides and set a solid gray background
                        for (int i = 0; i < presentation.Masters.Count; i++)
                        {
                            // Apply background settings (based on set-slide-background-master rule)
                            presentation.Masters[i].Background.Type = BackgroundType.OwnBackground;
                            presentation.Masters[i].Background.FillFormat.FillType = FillType.Solid;
                            presentation.Masters[i].Background.FillFormat.SolidFillColor.Color = Color.Gray;
                        }

                        // Define output file path
                        string outputFileName = "Processed_" + Path.GetFileName(filePath);
                        string outputPath = Path.Combine(inputFolder, outputFileName);

                        // Save the modified presentation
                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
                catch (Aspose.Slides.PptxReadException)
                {
                    // Format not supported or corrupted file
                    Console.WriteLine("Unsupported or corrupted PPTX file: " + filePath);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
                }
            }
        }
    }
}