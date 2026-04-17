using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MeasureFallbackFontPerformance
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPathNoFallback = "slide_no_fallback.png";
            string outputPathWithFallback = "slide_with_fallback.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // -------------------- Rendering without fallback fonts --------------------
                Stopwatch stopwatchNoFallback = new Stopwatch();
                stopwatchNoFallback.Start();

                // Render the first slide to an image
                Aspose.Slides.IImage imageNoFallback = presentation.Slides[0].GetImage(1f, 1f);
                stopwatchNoFallback.Stop();

                // Save the rendered image
                imageNoFallback.Save(outputPathNoFallback, Aspose.Slides.ImageFormat.Png);
                Console.WriteLine("Rendering without fallback took: " + stopwatchNoFallback.ElapsedMilliseconds + " ms");

                // -------------------- Add fallback font rule --------------------
                Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
                // Example: Unicode range 0x400-0x4FF (Cyrillic) fallback to Times New Roman
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // -------------------- Rendering with fallback fonts --------------------
                Stopwatch stopwatchWithFallback = new Stopwatch();
                stopwatchWithFallback.Start();

                Aspose.Slides.IImage imageWithFallback = presentation.Slides[0].GetImage(1f, 1f);
                stopwatchWithFallback.Stop();

                // Save the rendered image
                imageWithFallback.Save(outputPathWithFallback, Aspose.Slides.ImageFormat.Png);
                Console.WriteLine("Rendering with fallback took: " + stopwatchWithFallback.ElapsedMilliseconds + " ms");

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., loading errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}