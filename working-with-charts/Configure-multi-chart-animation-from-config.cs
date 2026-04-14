using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace ConfigureMultiChartAnimation
{
    // Represents animation configuration for a single chart.
    public class ChartConfig
    {
        public int SlideIndex { get; set; }
        public string ChartType { get; set; }               // e.g., "ClusteredColumn"
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string MajorGrouping { get; set; }           // "BySeries" or "ByCategory"
        public int MajorIndex { get; set; }                 // series or category index
        public string MinorGrouping { get; set; }           // optional: "ByElementInSeries" etc.
        public int SeriesIndex { get; set; }                // for minor grouping
        public int CategoryIndex { get; set; }              // for minor grouping
        public string EffectType { get; set; }              // e.g., "Fade"
        public string EffectSubtype { get; set; }           // e.g., "None"
        public string TriggerType { get; set; }             // e.g., "OnClick"
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Path to the JSON configuration file.
            string configPath = "config.json";

            // Verify that the configuration file exists.
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuration file not found: " + configPath);
                return;
            }

            List<ChartConfig> chartConfigs;
            try
            {
                // Read and deserialize the configuration.
                string json = File.ReadAllText(configPath);
                chartConfigs = JsonSerializer.Deserialize<List<ChartConfig>>(json);
                if (chartConfigs == null)
                {
                    Console.WriteLine("Configuration file is empty or invalid.");
                    return;
                }
            }
            catch (Exception ex)
            {
                // Handle JSON parsing errors.
                Console.WriteLine("Failed to parse configuration file: " + ex.Message);
                return;
            }

            // Create a new presentation.
            using (Presentation pres = new Presentation())
            {
                // Ensure there is at least one slide to work with.
                if (pres.Slides.Count == 0)
                {
                    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                }

                foreach (ChartConfig cfg in chartConfigs)
                {
                    // Validate slide index.
                    if (cfg.SlideIndex < 0 || cfg.SlideIndex >= pres.Slides.Count)
                    {
                        Console.WriteLine("Invalid slide index: " + cfg.SlideIndex);
                        continue;
                    }

                    ISlide slide = pres.Slides[cfg.SlideIndex];

                    // Parse the chart type enum.
                    ChartType chartType;
                    if (!Enum.TryParse(cfg.ChartType, out chartType))
                    {
                        Console.WriteLine("Unsupported chart type: " + cfg.ChartType);
                        continue; // format not supported
                    }

                    // Add the chart to the slide.
                    IChart chart = slide.Shapes.AddChart(chartType, cfg.X, cfg.Y, cfg.Width, cfg.Height);

                    // Apply major grouping animation if specified.
                    if (!string.IsNullOrEmpty(cfg.MajorGrouping))
                    {
                        EffectChartMajorGroupingType majorGroup;
                        if (Enum.TryParse(cfg.MajorGrouping, out majorGroup))
                        {
                            EffectType effectType;
                            EffectSubtype effectSubtype;
                            EffectTriggerType triggerType;

                            if (Enum.TryParse(cfg.EffectType, out effectType) &&
                                Enum.TryParse(cfg.EffectSubtype, out effectSubtype) &&
                                Enum.TryParse(cfg.TriggerType, out triggerType))
                            {
                                slide.Timeline.MainSequence.AddEffect(
                                    chart,
                                    majorGroup,
                                    cfg.MajorIndex,
                                    effectType,
                                    effectSubtype,
                                    triggerType);
                            }
                        }
                    }

                    // Apply minor grouping animation if specified.
                    if (!string.IsNullOrEmpty(cfg.MinorGrouping))
                    {
                        EffectChartMinorGroupingType minorGroup;
                        if (Enum.TryParse(cfg.MinorGrouping, out minorGroup))
                        {
                            EffectType effectType;
                            EffectSubtype effectSubtype;
                            EffectTriggerType triggerType;

                            if (Enum.TryParse(cfg.EffectType, out effectType) &&
                                Enum.TryParse(cfg.EffectSubtype, out effectSubtype) &&
                                Enum.TryParse(cfg.TriggerType, out triggerType))
                            {
                                slide.Timeline.MainSequence.AddEffect(
                                    chart,
                                    minorGroup,
                                    cfg.SeriesIndex,
                                    cfg.CategoryIndex,
                                    effectType,
                                    effectSubtype,
                                    triggerType);
                            }
                        }
                    }
                }

                // Save the presentation.
                try
                {
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors.
                    Console.WriteLine("Failed to save presentation: " + ex.Message);
                }
            }
        }
    }
}