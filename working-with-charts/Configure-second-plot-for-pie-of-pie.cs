using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define chart parameters
            int slideIndex = 0;
            float x = 50f;
            float y = 50f;
            float width = 500f;
            float height = 400f;
            int seriesIndex = 0;
            bool showValue = true;
            ushort secondPieSize = 150; // size of second pie in percent
            double splitPosition = 30.0; // custom split position

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a Pie of Pie chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[slideIndex].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.PieOfPie, x, y, width, height);

            // Show values on data labels
            chart.ChartData.Series[seriesIndex].Labels.DefaultDataLabelFormat.ShowValue = showValue;

            // Configure second plot options
            chart.ChartData.Series[seriesIndex].ParentSeriesGroup.SecondPieSize = secondPieSize;
            chart.ChartData.Series[seriesIndex].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
            chart.ChartData.Series[seriesIndex].ParentSeriesGroup.PieSplitPosition = splitPosition;

            // Save the presentation
            string outputPath = "SecondPlotPieOfPie.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}