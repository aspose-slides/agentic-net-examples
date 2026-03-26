using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MathEquationRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file containing mathematical equations
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "Equations.pptx");
            // Output folder for JPEG images
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "EquationImages");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through each slide
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];

                    // Generate full‑scale image of the slide (contains the equation)
                    Aspose.Slides.IImage image = slide.GetImage(1f, 1f);

                    // Build output file name
                    string outputPath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}_Equation.jpg");

                    // Save as JPEG
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save presentation (optional, as we only read)
                string tempSavePath = Path.Combine(Directory.GetCurrentDirectory(), "temp_save.pptx");
                pres.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Equation images have been saved to: " + outputDir);
        }
    }
}