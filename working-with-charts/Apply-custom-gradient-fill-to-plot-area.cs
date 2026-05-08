using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyCustomGradientFillToPlotArea
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

                // Apply a gradient fill to the chart's plot area
                chart.PlotArea.Format.Fill.FillType = FillType.Gradient;
                chart.PlotArea.Format.Fill.GradientFormat.GradientDirection = GradientDirection.FromCorner1;
                chart.PlotArea.Format.Fill.GradientFormat.GradientShape = GradientShape.Rectangle;

                // Define gradient stops
                chart.PlotArea.Format.Fill.GradientFormat.GradientStops.Clear();
                chart.PlotArea.Format.Fill.GradientFormat.GradientStops.Add(0f, Color.LightBlue);
                chart.PlotArea.Format.Fill.GradientFormat.GradientStops.Add(1f, Color.DarkBlue);

                // Save the presentation
                try
                {
                    pres.Save("CustomGradientPlotArea.pptx", SaveFormat.Pptx);
                }
                catch (ArgumentException ex)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("The specified format is not supported: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
                }
            }
        }
    }
}