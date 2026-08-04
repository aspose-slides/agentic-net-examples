// -----------------------------------------------------------------------------
// Example: Load presentation async add chart animations using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation asynchronously, add a
// chart to the first slide, generate slide animations (including the chart),
// and save the result using Aspose.Slides for .NET. The example illustrates
// non‑blocking presentation loading and animation generation suitable for
// console or UI applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Async,
// Chart, Animations, Presentation Processing, Office Automation
//
// Use Cases:
// - Load large presentations without freezing the UI.
// - Programmatically add charts and generate animations.
// - Automate PPTX modification and animation creation in .NET tools.
// - Validate and preview presentation workflows before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static async Task Main(string[] args)
    {
        // Paths for input and output files
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation asynchronously to avoid blocking the UI thread
            presentation = await LoadPresentationAsync(inputPath);
        }
        catch (NotSupportedException)
        {
            // The file format is not supported by Aspose.Slides
            Console.WriteLine("File format not supported.");
            return;
        }
        catch (Exception ex)
        {
            // General loading error
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Add a sample chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(
            ChartType.ClusteredColumn,
            50f, 50f, 400f, 300f);

        // Generate animations for all slides (including the newly added chart)
        using (PresentationAnimationsGenerator animationsGenerator =
            new PresentationAnimationsGenerator(presentation.SlideSize.Size.ToSize()))
        {
            // Run the animation generation; this call is quick and does not block UI
            animationsGenerator.Run(presentation.Slides);
        }

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }

    // Helper method to load a presentation on a background thread
    private static Task<Aspose.Slides.Presentation> LoadPresentationAsync(string path)
    {
        return Task.Run(() =>
        {
            // LoadOptions can be customized here if needed
            return new Aspose.Slides.Presentation(path);
        });
    }
}
