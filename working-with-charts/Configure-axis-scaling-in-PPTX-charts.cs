using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AxisScalingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
                chart.ValidateChartLayout();

                // Configure vertical axis scaling
                chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
                chart.Axes.VerticalAxis.MaxValue = 100.0;
                chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
                chart.Axes.VerticalAxis.MinValue = 0.0;
                chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
                chart.Axes.VerticalAxis.MajorUnit = 20.0;
                chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
                chart.Axes.VerticalAxis.MinorUnit = 5.0;

                // Configure horizontal axis scaling (optional)
                chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
                chart.Axes.HorizontalAxis.MajorUnit = 1.0;
                chart.Axes.HorizontalAxis.IsAutomaticMinorUnit = false;
                chart.Axes.HorizontalAxis.MinorUnit = 0.5;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}