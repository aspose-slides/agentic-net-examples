// -----------------------------------------------------------------------------
// Example: Export animated chart as high resolution PNG using C#
//
// Description:
// Demonstrates how to create a clustered column chart, apply fade and series
// appear animations, and export the start and end frames of the animation as
// high‑resolution PNG images using Aspose.Slides for .NET. The example shows
// how to generate a presentation, add chart animations, save the PPTX, and
// capture animation frames in a console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Animated, Chart,
// High, Resolution, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of animated charts and capture key animation frames.
// - Build C# tools for exporting animated chart visuals as high‑resolution images.
// - Integrate chart animation export into .NET presentation processing pipelines.
// - Validate and preview animated chart outputs before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AnimatedChartExport
{
    class Program
    {
        static void Main()
        {
            // Output paths
            string presentationPath = "AnimatedChart.pptx";
            string framesFolder = "Frames";

            // Ensure frames folder exists
            Directory.CreateDirectory(framesFolder);

            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add a clustered column chart
                    IChart chart = presentation.Slides[0].Shapes.AddChart(
                        ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Apply animations to the chart (fade + series appear)
                    ISlide slide = presentation.Slides[0];
                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        EffectType.Fade,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);

                    Sequence sequence = (Sequence)slide.Timeline.MainSequence;
                    // Add series animation effects for series indices 0 to 3
                    sequence.AddEffect(
                        chart,
                        EffectChartMajorGroupingType.BySeries,
                        0,
                        EffectType.Appear,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);
                    sequence.AddEffect(
                        chart,
                        EffectChartMajorGroupingType.BySeries,
                        1,
                        EffectType.Appear,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);
                    sequence.AddEffect(
                        chart,
                        EffectChartMajorGroupingType.BySeries,
                        2,
                        EffectType.Appear,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);
                    sequence.AddEffect(
                        chart,
                        EffectChartMajorGroupingType.BySeries,
                        3,
                        EffectType.Appear,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);

                    // Save the presentation before exiting
                    presentation.Save(presentationPath, SaveFormat.Pptx);

                    // Generate animation frames and export as high‑resolution PNG images
                    using (PresentationAnimationsGenerator animationsGenerator =
                        new PresentationAnimationsGenerator(presentation))
                    {
                        using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33))
                        {
                            animationsGenerator.NewAnimation += animationPlayer =>
                            {
                                // First frame (start of animation)
                                animationPlayer.SetTimePosition(0);
                                IImage startFrame = animationPlayer.GetFrame();
                                startFrame.Save(Path.Combine(framesFolder, "frame_start.png"),
                                    ImageFormat.Png);

                                // Last frame (end of animation)
                                animationPlayer.SetTimePosition(animationPlayer.Duration);
                                IImage endFrame = animationPlayer.GetFrame();
                                endFrame.Save(Path.Combine(framesFolder, "frame_end.png"),
                                    ImageFormat.Png);
                            };

                            // Run the animation generator for all slides
                            animationsGenerator.Run(presentation.Slides);
                        }
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
