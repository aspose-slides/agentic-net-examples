// -----------------------------------------------------------------------------
// Example: Generate PNG thumbnail for each chart using C#
//
// Description:
// Demonstrates how to generate PNG thumbnails for every chart in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example loads an
// existing presentation (if available) or creates a new one with a sample chart,
// optionally adjusts chart layout, extracts each chart as an image, and saves
// the thumbnails as PNG files. It also saves the (potentially modified) presentation.
// This pattern helps automate PPTX chart processing, thumbnail generation, and
// presentation validation in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Generate, Thumbnail, Each,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of PNG thumbnails for all charts in a presentation.
// - Build C# tools for extracting and processing chart images from PPTX files.
// - Integrate chart thumbnail creation into .NET workflows or reporting systems.
// - Validate and preview chart visuals before publishing or further transformation.
// -----------------------------------------------------------------------------
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
