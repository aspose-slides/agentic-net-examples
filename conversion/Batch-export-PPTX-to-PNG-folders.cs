using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchExportPptxToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output directories (defaults if not provided)
            string inputDir = args.Length > 0 ? args[0] : "Input";
            string outputDir = args.Length > 1 ? args[1] : "Output";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            // Ensure output base directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all PPTX files in the input directory
            string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");
            foreach (string pptxPath in pptxFiles)
            {
                // Verify the file exists (redundant but safe)
                if (!File.Exists(pptxPath))
                {
                    Console.WriteLine("File not found: " + pptxPath);
                    continue;
                }

                // Create a folder named after the presentation title
                string presentationTitle = Path.GetFileNameWithoutExtension(pptxPath);
                string presentationOutputDir = Path.Combine(outputDir, presentationTitle);
                if (!Directory.Exists(presentationOutputDir))
                {
                    Directory.CreateDirectory(presentationOutputDir);
                }

                try
                {
                    // Load the presentation
                    using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptxPath))
                    {
                        // Save the presentation before exiting (as required)
                        string savedPresentationPath = Path.Combine(presentationOutputDir, presentationTitle + ".pptx");
                        pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

                        // Export each slide to PNG using the recommended pattern
                        for (int index = 0; index < pres.Slides.Count; index++)
                        {
                            Aspose.Slides.ISlide slide = pres.Slides[index];
                            using (Aspose.Slides.IImage image = slide.GetImage())
                            {
                                string outputPath = String.Format(Path.Combine(presentationOutputDir, "Slide_{0}.png"), index + 1);
                                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("Format not supported for file: " + pptxPath);
                }
                catch (Exception ex)
                {
                    // General error handling
                    Console.WriteLine("Error processing file: " + pptxPath);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}