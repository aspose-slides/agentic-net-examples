using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input directory containing PPT files
        string inputDir = args.Length > 0 ? args[0] : Path.Combine(Environment.CurrentDirectory, "InputPpt");
        // Output base directory for SVG files
        string outputBaseDir = args.Length > 1 ? args[1] : Path.Combine(Environment.CurrentDirectory, "OutputSvg");

        if (!Directory.Exists(inputDir))
        {
            Console.WriteLine("Input directory does not exist: " + inputDir);
            return;
        }

        if (!Directory.Exists(outputBaseDir))
        {
            Directory.CreateDirectory(outputBaseDir);
        }

        // Get all PPT and PPTX files
        string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt*");
        foreach (string pptPath in pptFiles)
        {
            if (!File.Exists(pptPath))
            {
                Console.WriteLine("File not found: " + pptPath);
                continue;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(pptPath);

                // Create output folder for this presentation
                string presentationName = Path.GetFileNameWithoutExtension(pptPath);
                string outputDir = Path.Combine(outputBaseDir, presentationName);
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Convert each slide to SVG
                for (int index = 0; index < pres.Slides.Count; index++)
                {
                    ISlide slide = pres.Slides[index];
                    string svgPath = Path.Combine(outputDir, $"slide_{index + 1}.svg");
                    using (FileStream stream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                    {
                        slide.WriteAsSvg(stream);
                    }
                }

                // Save presentation before exit (preserve original format if possible)
                try
                {
                    pres.Save(pptPath, SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported for saving as PPTX; attempt original format
                    // Comment: format not supported
                }

                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Comment: format not supported
                Console.WriteLine("Unsupported format for file: " + pptPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file " + pptPath + ": " + ex.Message);
            }
        }
    }
}