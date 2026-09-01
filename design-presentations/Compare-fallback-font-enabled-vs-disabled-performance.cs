// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Measure rendering performance with and without font fallback using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, render the first slide

// to PNG images, and compare the rendering time when font fallback is disabled

// versus enabled. The example uses Aspose.Slides for .NET to configure

// FontFallBackRules, capture rendering duration with Stopwatch, and save the

// resulting images and a modified presentation. This pattern helps developers

// benchmark font fallback impact on slide rendering performance.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, FontFallback, Rendering Performance,

// Image Export, Stopwatch, Benchmark, .NET

//

// Use Cases:

// - Benchmark slide rendering speed with font fallback disabled and enabled.

// - Evaluate the performance impact of custom font fallback rules.

// - Automate generation of slide images for reporting or preview purposes.

// - Integrate rendering performance tests into CI pipelines.

// -----------------------------------------------------------------------------

using System;

using System.Diagnostics;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFallbackPerformanceTest

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "large.pptx";

            string outputPathDisabled = "render_without_fallback.png";

            string outputPathEnabled = "render_with_fallback.png";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Render without fallback fonts

                Stopwatch stopwatchDisabled = new Stopwatch();

                stopwatchDisabled.Start();

                Aspose.Slides.IImage imageDisabled = presentation.Slides[0].GetImage(1f, 1f);

                stopwatchDisabled.Stop();

                imageDisabled.Save(outputPathDisabled, Aspose.Slides.ImageFormat.Png);

                imageDisabled.Dispose();



                // Enable fallback fonts

                Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();

                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;



                // Render with fallback fonts

                Stopwatch stopwatchEnabled = new Stopwatch();

                stopwatchEnabled.Start();

                Aspose.Slides.IImage imageEnabled = presentation.Slides[0].GetImage(1f, 1f);

                stopwatchEnabled.Stop();

                imageEnabled.Save(outputPathEnabled, Aspose.Slides.ImageFormat.Png);

                imageEnabled.Dispose();



                Console.WriteLine($"Rendering without fallback: {stopwatchDisabled.ElapsedMilliseconds} ms");

                Console.WriteLine($"Rendering with fallback: {stopwatchEnabled.ElapsedMilliseconds} ms");



                // Save presentation before exit

                presentation.Save("modified_output.pptx", SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

