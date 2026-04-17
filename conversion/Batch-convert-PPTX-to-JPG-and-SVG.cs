using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input folder containing PPTX files
        string inputFolder = "InputPptx";

        // Define output subfolders for JPG and SVG
        string jpgFolder = Path.Combine(inputFolder, "Jpg");
        string svgFolder = Path.Combine(inputFolder, "Svg");

        // Verify input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist: " + inputFolder);
            return;
        }

        // Ensure output folders exist
        Directory.CreateDirectory(jpgFolder);
        Directory.CreateDirectory(svgFolder);

        // Get all PPTX files in the input folder
        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");

        foreach (string filePath in pptxFiles)
        {
            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(filePath))
                {
                    // Export each slide to JPG
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        using (IImage slideImage = pres.Slides[i].GetImage())
                        {
                            string jpgPath = Path.Combine(
                                jpgFolder,
                                Path.GetFileNameWithoutExtension(filePath) + "_Slide" + (i + 1) + ".jpg");

                            slideImage.Save(jpgPath, Aspose.Slides.ImageFormat.Jpeg);
                        }
                    }

                    // Export each slide to SVG
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        string svgPath = Path.Combine(
                            svgFolder,
                            Path.GetFileNameWithoutExtension(filePath) + "_Slide" + (i + 1) + ".svg");

                        using (FileStream svgStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                        {
                            pres.Slides[i].WriteAsSvg(svgStream);
                        }
                    }

                    // Save the presentation (no modifications) to satisfy lifecycle rule
                    pres.Save(filePath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("File format not supported: " + filePath);
            }
            catch (Exception ex)
            {
                // General error handling (e.g., file access issues)
                Console.WriteLine("Error processing file: " + filePath);
                Console.WriteLine(ex.Message);
            }
        }
    }
}