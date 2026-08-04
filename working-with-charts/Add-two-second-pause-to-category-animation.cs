// -----------------------------------------------------------------------------
// Example: Add two second pause to category animation using C#
//
// Description:
// Demonstrates how to add a two‑second pause between category animation elements 
// of a chart using C# and Aspose.Slides for .NET. The example loads a PPTX file, 
// accesses the first chart on the first slide, applies an initial fade effect, 
// then animates each series element within each category with a 2‑second delay 
// after each effect. The modified presentation is saved as a new PPTX file. 
// Developers can use this pattern to automate chart animation timing, validate 
// presentation behavior, or integrate advanced animation control into .NET 
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Second, Pause, Category, 
// Animation, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a two‑second pause to category animations in chart slides.
// - Build C# tools for fine‑grained PowerPoint animation control.
// - Generate or transform PPTX files with custom animation sequences in .NET.
// - Validate and test presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = "Data" + Path.DirectorySeparatorChar;
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Get the first shape and cast it to a chart
                IShapeCollection shapes = slide.Shapes;
                IChart chart = shapes[0] as IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Add an initial fade effect for the chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Get the main sequence as a concrete Sequence object
                Sequence seq = (Sequence)slide.Timeline.MainSequence;

                // Determine the number of categories and series
                int categoryCount = chart.ChartData.Categories.Count;
                int seriesCount = chart.ChartData.Series.Count;

                // Animate each element in each category with a 2‑second pause between them
                for (int cat = 0; cat < categoryCount; cat++)
                {
                    for (int ser = 0; ser < seriesCount; ser++)
                    {
                        IEffect effect = seq.AddEffect(
                            chart,
                            EffectChartMinorGroupingType.ByElementInCategory,
                            ser,
                            cat,
                            EffectType.Appear,
                            EffectSubtype.None,
                            EffectTriggerType.AfterPrevious);

                        // Set a 2‑second delay after each effect
                        effect.Timing.TriggerDelayTime = 2.0f;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
