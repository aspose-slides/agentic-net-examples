using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomCalloutChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Enable the chart title and set its text
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Data");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

            // Ensure the first series exists (sample data is added by default)
            // Configure data labels to appear as callouts and show values
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation to a PPTX file
            presentation.Save("CustomCalloutChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}