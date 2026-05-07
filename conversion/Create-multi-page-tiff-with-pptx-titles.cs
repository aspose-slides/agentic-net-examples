using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MultiPageTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path (from arguments or default)
            string inputPath;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
                inputPath = args[0];
            else
                inputPath = "presentation.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output directory for TIFF files
            string outputDir = Path.Combine(Environment.CurrentDirectory, "TiffOutput");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through each slide
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        // Access slide by index
                        ISlide slide = pres.Slides[i];

                        // Attempt to retrieve slide title (fallback to slide number)
                        string title = "Slide_" + (i + 1);
                        if (slide.Shapes.Count > 0 && slide.Shapes[0].GetType().Name.Contains("AutoShape"))
                        {
                            // This is a simplistic placeholder for actual title extraction logic
                            // In real scenarios, inspect the shape type and text content
                            // title = ((IAutoShape)slide.Shapes[0]).TextFrame.Text;
                        }

                        // Sanitize title for file name
                        foreach (char invalidChar in Path.GetInvalidFileNameChars())
                            title = title.Replace(invalidChar.ToString(), "_");

                        // Output file path for the current slide
                        string outputPath = Path.Combine(outputDir, title + ".tiff");

                        // Configure TIFF options (default options are sufficient for this example)
                        TiffOptions tiffOptions = new TiffOptions();

                        // Save only the current slide as a single‑page TIFF
                        int[] slideIndices = new int[] { i + 1 }; // Slides are 1‑based for the Save method
                        pres.Save(outputPath, slideIndices, SaveFormat.Tiff, tiffOptions);
                    }

                    // Save the entire presentation as a multi‑page TIFF (optional)
                    string multiPageTiffPath = Path.Combine(outputDir, "AllSlides.tiff");
                    TiffOptions multiPageOptions = new TiffOptions();
                    pres.Save(multiPageTiffPath, SaveFormat.Tiff, multiPageOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}