using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

namespace ChartAnimationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = "Data\\";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string configPath = Path.Combine(dataDir, "animConfig.json");
            string outputPath = Path.Combine(dataDir, "output_animated.pptx");

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuration file not found: " + configPath);
                return;
            }

            // Load animation configuration
            List<AnimationConfig> configs;
            try
            {
                string json = File.ReadAllText(configPath);
                configs = JsonSerializer.Deserialize<List<AnimationConfig>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read configuration: " + ex.Message);
                return;
            }

            // Load presentation
            Presentation presentation;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Apply animations based on configuration
            foreach (AnimationConfig cfg in configs)
            {
                // Validate slide index
                if (cfg.SlideIndex < 0 || cfg.SlideIndex >= presentation.Slides.Count)
                    continue;

                ISlide slide = presentation.Slides[cfg.SlideIndex];

                // Validate chart index
                if (cfg.ChartIndex < 0 || cfg.ChartIndex >= slide.Shapes.Count)
                    continue;

                IChart chart = slide.Shapes[cfg.ChartIndex] as IChart;
                if (chart == null)
                    continue;

                // Add initial fade effect
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Use the main sequence for further effects
                Sequence seq = (Sequence)slide.Timeline.MainSequence;

                // Apply series or category based animations
                if (cfg.Grouping.Equals("BySeries", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (int seriesIdx in cfg.Indices)
                    {
                        seq.AddEffect(
                            chart,
                            EffectChartMajorGroupingType.BySeries,
                            seriesIdx,
                            EffectType.Appear,
                            EffectSubtype.None,
                            EffectTriggerType.AfterPrevious);
                    }
                }
                else if (cfg.Grouping.Equals("ByCategory", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (int catIdx in cfg.Indices)
                    {
                        seq.AddEffect(
                            chart,
                            EffectChartMajorGroupingType.ByCategory,
                            catIdx,
                            EffectType.Appear,
                            EffectSubtype.None,
                            EffectTriggerType.AfterPrevious);
                    }
                }
            }

            // Save the presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other save error
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }

    // Configuration class matching the JSON structure
    public class AnimationConfig
    {
        public int SlideIndex { get; set; }
        public int ChartIndex { get; set; }
        public string Grouping { get; set; } // "BySeries" or "ByCategory"
        public List<int> Indices { get; set; } // Series or category indices
    }
}