// -----------------------------------------------------------------------------
// Example: Add series animation to charts in PPTX using C#
//
// Description:
// Demonstrates how to add a series animation to each chart series in a PPTX
// presentation using C# and Aspose.Slides for .NET. The example loads one or
// more presentations, iterates through all slides and chart shapes, applies an
// "Appear" animation effect to each series, and saves the modified file with a
// new name.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Series Animation, Charts,
// Animation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding series‑by‑series animation to charts in existing PPTX files.
// - Build .NET tools for enhancing PowerPoint presentations with custom animations.
// - Generate or transform PPTX files programmatically with animated chart series.
// - Validate and preview presentation workflows before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX files – either from command‑line arguments or a default list
        string[] inputFiles = args.Length > 0 ? args : new string[] { "input1.pptx", "input2.pptx" };

        foreach (string inputPath in inputFiles)
        {
            try
            {
                // Verify that the file exists before attempting to load it
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("File not found: " + inputPath);
                    continue;
                }

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a chart
                            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                            if (chart != null)
                            {
                                // Add the same series animation to each series in the chart
                                int seriesCount = chart.ChartData.Series.Count;
                                for (int i = 0; i < seriesCount; i++)
                                {
                                    // Animate the series on click using the Appear effect
                                    slide.Timeline.MainSequence.AddEffect(
                                        chart,
                                        Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                                        i,
                                        Aspose.Slides.Animation.EffectType.Appear,
                                        Aspose.Slides.Animation.EffectSubtype.None,
                                        Aspose.Slides.Animation.EffectTriggerType.OnClick);
                                }
                            }
                        }
                    }

                    // Prepare output file name
                    string outputPath = Path.Combine(
                        Path.GetDirectoryName(inputPath),
                        Path.GetFileNameWithoutExtension(inputPath) + "_animated.pptx");

                    try
                    {
                        // Save the modified presentation
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported – write a comment and continue
                        Console.WriteLine("Save format not supported for file: " + inputPath);
                    }
                }
            }
            catch (Exception ex)
            {
                // General error handling (e.g., loading errors, I/O issues)
                Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);
            }
        }
    }
}
