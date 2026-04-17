using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input directory containing PPT files
        string inputDir = args.Length > 0 ? args[0] : "InputPpt";
        // Output directory for converted PPTX files
        string outputDir = args.Length > 1 ? args[1] : "OutputPptx";
        // Path to the external theme file (.thmx)
        string themePath = args.Length > 2 ? args[2] : "theme.thmx";

        // Verify input directory exists
        if (!Directory.Exists(inputDir))
        {
            Console.WriteLine("Input directory does not exist: " + inputDir);
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Get all PPT files in the input directory
        string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt");
        foreach (string pptFile in pptFiles)
        {
            try
            {
                // Load the PPT presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptFile);

                // Apply the external theme to each master slide
                foreach (Aspose.Slides.IMasterSlide master in pres.Masters)
                {
                    master.ApplyExternalThemeToDependingSlides(themePath);
                }

                // Determine output file path with .pptx extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptFile);
                string outPath = Path.Combine(outputDir, fileNameWithoutExt + ".pptx");

                // Save the presentation as PPTX
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Converted: " + pptFile);
            }
            catch (Aspose.Slides.PptxReadException)
            {
                // Theme could not be applied
                Console.WriteLine("Failed to apply theme to: " + pptFile);
            }
            catch (NotSupportedException)
            {
                // format not supported
                Console.WriteLine("Format not supported for file: " + pptFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + pptFile + " - " + ex.Message);
            }
        }
    }
}