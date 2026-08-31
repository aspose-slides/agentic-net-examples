// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Measure rendering time fallback enabled vs disabled using C#

//

// Description:

// Demonstrates how to measure the rendering time of a slide when font fallback

// is disabled versus when it is enabled using C# and Aspose.Slides for .NET.

// The example loads a PPTX file, renders the first slide to PNG twice—once

// without any font fallback rules and once with a fallback rule applied—while

// timing each operation. It outputs the elapsed times and saves the rendered

// images and a copy of the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Measure, Rendering, Time,

// Fallback, Presentation Processing, Office Automation

//

// Use Cases:

// - Compare slide rendering performance with and without font fallback.

// - Benchmark Aspose.Slides rendering under different font handling settings.

// - Automate generation of slide images for reporting or preview purposes.

// - Validate that fallback fonts do not adversely affect rendering speed.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Diagnostics;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputWithoutFallback = "slide_without_fallback.png";

        string outputWithFallback = "slide_with_fallback.png";



        // Check if input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load presentation

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            // Render without fallback fonts and measure time

            Stopwatch swWithout = Stopwatch.StartNew();

            Aspose.Slides.IImage imgWithout = pres.Slides[0].GetImage(1f, 1f);

            imgWithout.Save(outputWithoutFallback, Aspose.Slides.ImageFormat.Png);

            imgWithout.Dispose();

            swWithout.Stop();



            // Set fallback font rules

            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            pres.FontsManager.FontFallBackRulesCollection = rules;



            // Render with fallback fonts and measure time

            Stopwatch swWith = Stopwatch.StartNew();

            Aspose.Slides.IImage imgWith = pres.Slides[0].GetImage(1f, 1f);

            imgWith.Save(outputWithFallback, Aspose.Slides.ImageFormat.Png);

            imgWith.Dispose();

            swWith.Stop();



            // Output timing results

            Console.WriteLine("Rendering time without fallback: {0} ms", swWithout.ElapsedMilliseconds);

            Console.WriteLine("Rendering time with fallback: {0} ms", swWith.ElapsedMilliseconds);



            // Save presentation before exit

            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (NotSupportedException)

        {

            // format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

