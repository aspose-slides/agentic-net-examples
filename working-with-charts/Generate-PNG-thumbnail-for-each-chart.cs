using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace GenerateChartThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (optional)
            string inputPath = "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";

            // Create or load presentation
            if (File.Exists(inputPath))
            {
                try
                {
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        ProcessPresentation(pres);
                        pres.Save(outputPath, SaveFormat.Pptx);
                    }
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other loading errors
                    Console.WriteLine("Failed to load presentation: " + ex.Message);
                }
            }
            else
            {
                using (Presentation pres = new Presentation())
                {
                    // Add a sample chart to the first slide
                    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);
                    // Adjust layout: set gap width via the series group
                    if (chart.ChartData.Series.Count > 0)
                    {
                        IChartSeries firstSeries = chart.ChartData.Series[0];
                        firstSeries.ParentSeriesGroup.GapWidth = 150; // 150% gap width
                    }

                    // Generate thumbnail for the newly added chart
                    IImage chartImage = chart.GetImage();
                    chartImage.Save("Chart_0.png", ImageFormat.Png);

                    // Save the presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }

        // Processes all slides and generates PNG thumbnails for each chart
        private static void ProcessPresentation(Presentation pres)
        {
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    if (shape is IChart)
                    {
                        IChart chart = (IChart)shape;

                        // Example layout adjustment: set gap width for the first series group
                        if (chart.ChartData.Series.Count > 0)
                        {
                            IChartSeries series = chart.ChartData.Series[0];
                            series.ParentSeriesGroup.GapWidth = 120; // Adjust as needed
                        }

                        // Generate and save PNG thumbnail for the chart
                        IImage chartImage = chart.GetImage();
                        string fileName = $"Chart_Slide{slideIndex + 1}_Shape{shapeIndex + 1}.png";
                        chartImage.Save(fileName, ImageFormat.Png);
                    }
                }
            }
        }
    }
}