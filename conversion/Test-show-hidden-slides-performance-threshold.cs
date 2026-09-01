// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test show hidden slides performance threshold using C#

//

// Description:

// Demonstrates how to measure the impact on conversion time when exporting hidden

// slides versus excluding them, using Aspose.Slides for .NET to convert a PPTX

// to GIF and evaluate the result against a defined performance threshold.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Test, Show, Hidden, Slides,

// Conversion, Performance, GIF, Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Benchmark hidden slide export performance.

// - Automate testing of conversion time thresholds.

// - Validate that enabling ExportHiddenSlides does not degrade performance beyond

//   acceptable limits.

// - Integrate performance checks into CI pipelines for PowerPoint processing tools.

// - Generate GIFs from presentations with or without hidden slides.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Diagnostics;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define file paths and threshold

        string inputPath = "input.pptx";

        string outputPathWithoutHidden = "output_no_hidden.gif";

        string outputPathWithHidden = "output_hidden.gif";

        const long thresholdMilliseconds = 500; // acceptable increase in conversion time



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Hide the first slide to test ExportHiddenSlides effect

            if (presentation.Slides.Count > 0)

            {

                presentation.Slides[0].Hidden = true;

            }



            // Prepare GIF options without hidden slides

            Aspose.Slides.Export.GifOptions gifOptionsNoHidden = new Aspose.Slides.Export.GifOptions();

            gifOptionsNoHidden.ExportHiddenSlides = false;

            gifOptionsNoHidden.FrameSize = new Size(960, 720);

            gifOptionsNoHidden.DefaultDelay = 2000;

            gifOptionsNoHidden.TransitionFps = 35;



            // Measure conversion time without hidden slides

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            presentation.Save(outputPathWithoutHidden, Aspose.Slides.Export.SaveFormat.Gif, gifOptionsNoHidden);

            stopwatch.Stop();

            long timeWithoutHidden = stopwatch.ElapsedMilliseconds;



            // Prepare GIF options with hidden slides

            Aspose.Slides.Export.GifOptions gifOptionsWithHidden = new Aspose.Slides.Export.GifOptions();

            gifOptionsWithHidden.ExportHiddenSlides = true;

            gifOptionsWithHidden.FrameSize = new Size(960, 720);

            gifOptionsWithHidden.DefaultDelay = 2000;

            gifOptionsWithHidden.TransitionFps = 35;



            // Measure conversion time with hidden slides

            stopwatch.Reset();

            stopwatch.Start();

            presentation.Save(outputPathWithHidden, Aspose.Slides.Export.SaveFormat.Gif, gifOptionsWithHidden);

            stopwatch.Stop();

            long timeWithHidden = stopwatch.ElapsedMilliseconds;



            // Evaluate whether the time increase is within the defined threshold

            long timeDifference = timeWithHidden - timeWithoutHidden;

            if (timeDifference <= thresholdMilliseconds)

            {

                Console.WriteLine("Conversion time increase is within the acceptable threshold.");

            }

            else

            {

                Console.WriteLine("Conversion time increase exceeds the acceptable threshold.");

            }



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., file access, network issues)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

