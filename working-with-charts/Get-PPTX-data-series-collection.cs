using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
                // Add a sample chart to the first slide for demonstration purposes
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);
                // The chart is initialized with a default series and category
            }

            // Access the first slide
            ISlide firstSlide = pres.Slides[0];

            // Locate the first chart on the slide
            IChart chartShape = null;
            foreach (IShape shape in firstSlide.Shapes)
            {
                if (shape is IChart)
                {
                    chartShape = (IChart)shape;
                    break;
                }
            }

            if (chartShape != null)
            {
                // Retrieve the series collection
                IChartSeriesCollection seriesCollection = chartShape.ChartData.Series;

                // Iterate through the series
                for (int i = 0; i < seriesCollection.Count; i++)
                {
                    IChartSeries series = seriesCollection[i];
                    // Example operation: set the fill color of each series to a solid color
                    series.Format.Fill.FillType = FillType.Solid;
                    // Use any color you prefer; here we use a predefined color
                    series.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Blue;
                }
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}