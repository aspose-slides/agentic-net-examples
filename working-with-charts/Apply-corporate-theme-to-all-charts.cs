using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Process only chart shapes
                        if (shape is Chart)
                        {
                            Chart chart = (Chart)shape;

                            // Apply corporate fill to the chart area
                            chart.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            chart.FillFormat.SolidFillColor.Color = Color.LightGray;

                            // Apply corporate colors to each series in the chart
                            for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                            {
                                IChartSeries series = chart.ChartData.Series[seriesIndex];

                                // Set solid fill for the series
                                series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                                series.Format.Fill.SolidFillColor.Color = Color.FromArgb(0, 120, 215); // corporate blue

                                // Enable varied colors for pie/donut charts
                                series.ParentSeriesGroup.IsColorVaried = true;
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access, external resources)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}