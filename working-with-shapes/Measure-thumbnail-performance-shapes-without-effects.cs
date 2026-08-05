// -----------------------------------------------------------------------------
// Example: Measure thumbnail performance for shapes with and without effects using C#
//
// Description:
// Demonstrates how to measure the performance of generating shape thumbnails 
// from a PowerPoint presentation using Aspose.Slides for .NET. The example 
// creates thumbnails for each shape twice – once using the shape bounds 
// (without visual effects) and once using the appearance bounds (including 
// effects) – and reports the elapsed time for each approach. This pattern helps 
// developers benchmark thumbnail generation and decide which method best fits 
// their performance requirements.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Measure, Thumbnail, 
// Performance, Shapes, Presentation Processing, Office Automation
//
// Use Cases:
// - Benchmark shape thumbnail generation with and without visual effects.
// - Optimize PowerPoint automation tools that need fast thumbnail previews.
// - Compare rendering performance for different thumbnail bounds.
// - Integrate performance measurements into .NET presentation processing pipelines.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                Stopwatch stopwatch = new Stopwatch();

                // Measure thumbnail generation without effects (Shape bounds)
                stopwatch.Start();
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1F, 1F))
                        {
                            // Thumbnail generated; dispose after use
                        }
                    }
                }
                stopwatch.Stop();
                Console.WriteLine("Time without effects: " + stopwatch.ElapsedMilliseconds + " ms");

                // Measure thumbnail generation with effects (Appearance bounds)
                stopwatch.Reset();
                stopwatch.Start();
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        using (IImage image = shape.GetImage(ShapeThumbnailBounds.Appearance, 1F, 1F))
                        {
                            // Thumbnail generated; dispose after use
                        }
                    }
                }
                stopwatch.Stop();
                Console.WriteLine("Time with effects: " + stopwatch.ElapsedMilliseconds + " ms");

                // Save the presentation (required before exit)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
