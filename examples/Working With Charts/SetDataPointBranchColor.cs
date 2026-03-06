using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace SetDataPointBranchColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a Sunburst chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Sunburst, 50f, 50f, 500f, 400f);

            // Access the data points collection of the first series
            IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

            // Example: Show value for the 4th data point (index 3)
            dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

            // Example: Customize label of the first data point (index 0) at level 2
            IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
            branch1Label.DataLabelFormat.ShowCategoryName = true;
            branch1Label.DataLabelFormat.ShowSeriesName = true;
            branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
            branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

            // Example: Set fill color for a specific data point (index 9)
            IFormat steam4Format = dataPoints[9].Format;
            steam4Format.Fill.FillType = FillType.Solid;
            steam4Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 255); // Blue with full opacity

            // Save the presentation
            presentation.Save("SetDataPointBranchColor_out.pptx", SaveFormat.Pptx);
        }
    }
}