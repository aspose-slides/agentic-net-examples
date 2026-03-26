using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CategoryAxisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Ensure there is at least one slide
            Aspose.Slides.ISlide slide;
            if (presentation.Slides.Count > 0)
            {
                slide = presentation.Slides[0];
            }
            else
            {
                slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Add a clustered column chart if none exists on the slide
            Aspose.Slides.Charts.IChart chart = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.Charts.IChart existingChart)
                {
                    chart = existingChart;
                    break;
                }
            }

            if (chart == null)
            {
                // Add a new chart with sample data
                chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
            }

            // Modify the category (horizontal) axis
            // Set label offset (distance of labels from the axis) – value between 0 and 1000%
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)200; // 20%

            // Set a custom number format for the axis labels
            chart.Axes.HorizontalAxis.NumberFormat = "0.00%";

            // Disable automatic min/max values and set custom range
            chart.Axes.HorizontalAxis.IsAutomaticMinValue = false;
            chart.Axes.HorizontalAxis.MinValue = 0.0;
            chart.Axes.HorizontalAxis.IsAutomaticMaxValue = false;
            chart.Axes.HorizontalAxis.MaxValue = 100.0;

            // Rotate tick labels for better readability
            chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45f;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}