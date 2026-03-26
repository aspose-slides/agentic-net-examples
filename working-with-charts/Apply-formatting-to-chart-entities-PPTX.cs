using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormattingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                // Create a new presentation because the input file does not exist
                Presentation pres = new Presentation();
                ISlide slide = pres.Slides[0];

                // Add a Sunburst chart
                IChart chart = slide.Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);

                // Access data points of the first series
                IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

                // Show value for a specific data point level
                dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

                // Customize label for a branch
                IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
                branch1Label.DataLabelFormat.ShowCategoryName = true;
                branch1Label.DataLabelFormat.ShowSeriesName = true;
                branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

                // Apply solid fill to another data point
                IFormat steam4Format = dataPoints[9].Format;
                steam4Format.Fill.FillType = FillType.Solid;
                steam4Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 255, 0); // ARGB green

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            else
            {
                // Load existing presentation
                Presentation pres = new Presentation(inputPath);
                ISlide slide = pres.Slides[0];

                // Assume the first shape is a chart
                IChart chart = slide.Shapes[0] as IChart;
                if (chart != null)
                {
                    // Change fill color of the first series
                    IChartSeries series = chart.ChartData.Series[0];
                    series.Format.Fill.FillType = FillType.Solid;
                    series.Format.Fill.SolidFillColor.Color = Color.Blue;
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}