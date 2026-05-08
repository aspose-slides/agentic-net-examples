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
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
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
                                    // Add animation for each series in the chart
                                    int seriesCount = chart.ChartData.Series.Count;
                                    for (int i = 0; i < seriesCount; i++)
                                    {
                                        slide.Timeline.MainSequence.AddEffect(
                                            chart,
                                            Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                                            i,
                                            Aspose.Slides.Animation.EffectType.Fade,
                                            Aspose.Slides.Animation.EffectSubtype.None,
                                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                                    }
                                }
                            }
                        }

                        // Save the modified presentation
                        string outputPath = Path.Combine(
                            inputFolder,
                            Path.GetFileNameWithoutExtension(filePath) + "_animated.pptx");
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
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