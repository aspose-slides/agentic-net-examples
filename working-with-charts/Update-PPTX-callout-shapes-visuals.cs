using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];

            // Add a clustered column chart
            var chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 400, 300, true);

            // Access the first series
            var series = chart.ChartData.Series[0];

            // Enable callout for data labels
            series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Modify the first data point's visual properties
            var dataPoint = series.DataPoints[0];

            // Fill color
            dataPoint.Format.Fill.FillType = FillType.Solid;
            dataPoint.Format.Fill.SolidFillColor.SchemeColor = SchemeColor.Accent1;

            // Line style
            dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
            dataPoint.Format.Line.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Dark1;
            dataPoint.Format.Line.Width = 2;

            // Text formatting for the callout label
            var label = dataPoint.Label;
            label.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 14f;
            label.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
            label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
            label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            presentation.Save("CalloutDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}