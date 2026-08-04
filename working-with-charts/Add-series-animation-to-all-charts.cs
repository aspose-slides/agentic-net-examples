// -----------------------------------------------------------------------------
// Example: Add series animation to all charts in PPTX files using C#
//
// Description:
// Demonstrates how to iterate through all PPTX files in a specified folder,
// locate every chart on each slide, and add a series‑by‑series fade animation
// to each chart using Aspose.Slides for .NET. The modified presentations are
// saved with an “_animated” suffix. This example is useful for batch processing
// of PowerPoint files to enhance chart visualizations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Charts, Series Animation, 
// Batch Processing, Presentation Automation, Office Automation, Timeline, 
// Effects
//
// Use Cases:
// - Automatically add series animation to charts across multiple presentations.
// - Build command‑line tools for bulk PowerPoint enhancement.
// - Integrate chart animation steps into .NET based document workflows.
// - Prepare presentations with consistent animation effects before distribution.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AddSeriesAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input folder: first argument or current directory
            string inputFolder = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

            // Get all PPTX files in the folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");

            foreach (string filePath in pptxFiles)
            {
                // Verify file existence
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File does not exist: " + filePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(filePath))
                    {
                        // Iterate through all slides
                        foreach (ISlide slide in presentation.Slides)
                        {
                            // Iterate through all shapes on the slide
                            foreach (IShape shape in slide.Shapes)
                            {
                                // Check if the shape is a chart
                                IChart chart = shape as IChart;
                                if (chart != null)
                                {
                                    // Add animation for each series in the chart
                                    int seriesCount = chart.ChartData.Series.Count;
                                    for (int i = 0; i < seriesCount; i++)
                                    {
                                        slide.Timeline.MainSequence.AddEffect(
                                            chart,
                                            EffectChartMajorGroupingType.BySeries,
                                            i,
                                            EffectType.Fade,
                                            EffectSubtype.None,
                                            EffectTriggerType.AfterPrevious);
                                    }
                                }
                            }
                        }

                        // Save the modified presentation
                        string outputPath = Path.Combine(
                            inputFolder,
                            Path.GetFileNameWithoutExtension(filePath) + "_animated.pptx");
                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported
                    Console.WriteLine("Unsupported format: " + filePath);
                }
                catch (Exception ex)
                {
                    // General error handling
                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
                }
            }
        }
    }
}
