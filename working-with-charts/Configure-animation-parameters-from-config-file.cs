using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string configPath = "config.json";

        // Verify configuration file existence
        if (!File.Exists(configPath))
        {
            Console.WriteLine("Configuration file not found: " + configPath);
            return;
        }

        // Read and deserialize configuration
        AnimationConfig[] configs;
        try
        {
            string json = File.ReadAllText(configPath);
            configs = JsonSerializer.Deserialize<AnimationConfig[]>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to parse configuration: " + ex.Message);
            return;
        }

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Ensure at least one slide exists
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Apply animation settings from configuration
            foreach (AnimationConfig cfg in configs)
            {
                // Validate slide index
                if (cfg.SlideIndex < 0 || cfg.SlideIndex >= presentation.Slides.Count)
                {
                    Console.WriteLine("Invalid slide index: " + cfg.SlideIndex);
                    continue;
                }

                Aspose.Slides.ISlide slide = presentation.Slides[cfg.SlideIndex];

                // Retrieve or create the target chart
                Aspose.Slides.Charts.IChart chart = null;
                if (cfg.ChartIndex >= 0 && cfg.ChartIndex < slide.Shapes.Count)
                {
                    chart = slide.Shapes[cfg.ChartIndex] as Aspose.Slides.Charts.IChart;
                }
                if (chart == null)
                {
                    chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);
                }

                // Convert string values to enum types
                EffectChartMajorGroupingType majorGrouping;
                EffectType effectType;
                EffectSubtype effectSubtype;
                EffectTriggerType triggerType;

                try
                {
                    majorGrouping = (EffectChartMajorGroupingType)Enum.Parse(typeof(EffectChartMajorGroupingType), cfg.MajorGrouping);
                    effectType = (EffectType)Enum.Parse(typeof(EffectType), cfg.EffectType);
                    effectSubtype = (EffectSubtype)Enum.Parse(typeof(EffectSubtype), cfg.EffectSubtype);
                    triggerType = (EffectTriggerType)Enum.Parse(typeof(EffectTriggerType), cfg.TriggerType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid enum value in configuration: " + ex.Message);
                    continue;
                }

                // Add the animation effect to the chart
                slide.Timeline.MainSequence.AddEffect(chart, majorGrouping, cfg.MajorIndex, effectType, effectSubtype, triggerType);
            }

            // Save the presentation
            try
            {
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }

    // Configuration model matching the JSON structure
    private class AnimationConfig
    {
        public int SlideIndex { get; set; }
        public int ChartIndex { get; set; }
        public string MajorGrouping { get; set; }
        public int MajorIndex { get; set; }
        public string EffectType { get; set; }
        public string EffectSubtype { get; set; }
        public string TriggerType { get; set; }
    }
}