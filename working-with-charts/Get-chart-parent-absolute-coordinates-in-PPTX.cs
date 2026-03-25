using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartParentCoordinates
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

                // Add a clustered column chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    100f, 100f, 500f, 350f);

                // Calculate actual layout values
                chart.ValidateChartLayout();

                // Chart's position on the slide
                float chartX = chart.X;
                float chartY = chart.Y;

                // Plot area actual coordinates relative to the chart
                float plotX = chart.PlotArea.ActualX;
                float plotY = chart.PlotArea.ActualY;
                float plotWidth = chart.PlotArea.ActualWidth;
                float plotHeight = chart.PlotArea.ActualHeight;

                // Absolute coordinates of the plot area on the slide
                float absolutePlotX = chartX + plotX;
                float absolutePlotY = chartY + plotY;

                Console.WriteLine("Chart Position: X={0}, Y={1}", chartX, chartY);
                Console.WriteLine("Plot Area Relative Position: X={0}, Y={1}", plotX, plotY);
                Console.WriteLine("Plot Area Size: Width={0}, Height={1}", plotWidth, plotHeight);
                Console.WriteLine("Plot Area Absolute Position on Slide: X={0}, Y={1}", absolutePlotX, absolutePlotY);

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