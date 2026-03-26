using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportMathEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation; can be passed as a command‑line argument
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Verify that the file exists before attempting to load it
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides and export each as a PNG image
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    // GetImage returns an IImage that must be disposed
                    using (IImage image = slide.GetImage())
                    {
                        string outputPath = $"slide_{index}.png";
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the (unchanged) presentation before exiting
                string savedPath = "output.pptx";
                presentation.Save(savedPath, SaveFormat.Pptx);
            }
        }
    }
}