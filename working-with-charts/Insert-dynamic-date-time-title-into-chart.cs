using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Set chart title with current date and time
            chart.HasTitle = true;
            string titleText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            chart.ChartTitle.AddTextFrameForOverriding(titleText);
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 30f;
            chart.ChartTitle.Width = 500f;
            chart.ChartTitle.Y = 10f;
            chart.ChartTitle.X = 50f;

            // Save the presentation
            string outputPath = "ChartWithDateTimeTitle.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
        }
    }
}