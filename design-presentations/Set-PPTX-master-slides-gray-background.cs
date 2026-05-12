using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetMasterSlideGrayBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            // Folder path can be passed as first argument; default to "input"
            string folderPath = args.Length > 0 ? args[0] : "input";

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("The specified folder does not exist.");
                return;
            }

            // Get all PPTX files in the folder
            string[] pptxFiles = Directory.GetFiles(folderPath, "*.pptx");

            foreach (string filePath in pptxFiles)
            {
                if (!File.Exists(filePath))
                {
                    // Skip if file somehow does not exist
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(filePath))
                    {
                        // Iterate through all master slides and set solid gray background
                        foreach (IMasterSlide masterSlide in presentation.Masters)
                        {
                            masterSlide.Background.Type = BackgroundType.OwnBackground;
                            masterSlide.Background.FillFormat.FillType = FillType.Solid;
                            masterSlide.Background.FillFormat.SolidFillColor.Color = Color.Gray;
                        }

                        // Prepare output path (creates a "Processed" subfolder)
                        string outputDirectory = Path.Combine(folderPath, "Processed");
                        Directory.CreateDirectory(outputDirectory);
                        string outputFilePath = Path.Combine(outputDirectory, Path.GetFileName(filePath));

                        // Save the modified presentation
                        presentation.Save(outputFilePath, SaveFormat.Pptx);
                    }
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported – comment as required
                    // Unsupported file format; skipping this file.
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., I/O errors)
                    Console.WriteLine($"Error processing file '{filePath}': {ex.Message}");
                }
            }
        }
    }
}