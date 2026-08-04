// -----------------------------------------------------------------------------
// Example: Configure category animation pause two seconds using C#
//
// Description:
// Demonstrates how to configure category animation pause two seconds using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Category, Animation, 
// Pause, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate configure category animation pause two seconds.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and file names
            string dataDir = "Data/";
            string inputFile = Path.Combine(dataDir, "input.pptx");
            string outputFile = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Load existing presentation if it exists, otherwise create a new one
            Presentation presentation = null;
            try
            {
                if (File.Exists(inputFile))
                {
                    presentation = new Presentation(inputFile);
                }
                else
                {
                    presentation = new Presentation();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                // Fallback to a new presentation
                presentation = new Presentation();
            }

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a chart if the slide does not contain any charts
            IChart chart = null;
            foreach (IShape shape in slide.Shapes)
            {
                chart = shape as IChart;
                if (chart != null)
                {
                    break;
                }
            }
            if (chart == null)
            {
                // Add a sample clustered column chart
                chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
            }

            // Add an initial fade effect to the chart
            slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

            // Get the main sequence as a concrete Sequence object
            Sequence seq = (Sequence)slide.Timeline.MainSequence;

            // Determine counts of categories and series
            int categoryCount = chart.ChartData.Categories.Count;
            int seriesCount = chart.ChartData.Series.Count;

            // Animate each element in each category with a 2‑second pause between categories
            for (int cat = 0; cat < categoryCount; cat++)
            {
                for (int ser = 0; ser < seriesCount; ser++)
                {
                    // Add the appearance effect for the specific series/category element
                    IEffect effect = seq.AddEffect(
                        chart,
                        EffectChartMinorGroupingType.ByElementInCategory,
                        ser,
                        cat,
                        EffectType.Appear,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);

                    // Set a negative delay (in seconds) to pause 2 seconds after this effect
                    // Negative value specifies delay in seconds according to the API documentation
                    effect.DelayBetweenTextParts = -2f;
                }
            }

            // Save the presentation, handling unsupported format exceptions
            try
            {
                presentation.Save(outputFile, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Comment: format not supported
                Console.WriteLine("Error saving presentation (format may not be supported): " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
