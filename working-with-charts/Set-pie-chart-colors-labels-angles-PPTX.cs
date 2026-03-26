using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace PieChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

            // Set chart title
            chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 20;
            chart.HasTitle = true;

            // Customize data labels
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

            // Set the angle of the first slice
            chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 45;

            // Explode the second slice
            chart.ChartData.Series[0].DataPoints[1].Explosion = 20;

            // Enable varied colors for slices
            chart.ChartData.Series[0].ParentSeriesGroup.IsColorVaried = true;

            // Save the presentation
            presentation.Save("CustomizedPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}