using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartLegendAndTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Validate layout to ensure actual positions are calculated
            chart.ValidateChartLayout();

            // Set chart title
            Aspose.Slides.Charts.ChartTitle chartTitle = (Aspose.Slides.Charts.ChartTitle)chart.ChartTitle;
            chartTitle.AddTextFrameForOverriding("Quarterly Sales");
            chartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chartTitle.Height = 30f;
            chart.HasTitle = true;

            // Customize legend position and size
            Aspose.Slides.Charts.Legend legend = (Aspose.Slides.Charts.Legend)chart.Legend;
            legend.X = 0.75f;   // Position from left (as fraction of chart width)
            legend.Y = 0.05f;   // Position from top (as fraction of chart height)
            legend.Width = 0.20f;
            legend.Height = 0.20f;

            // Save the presentation
            pres.Save("ChartLegendTitle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}