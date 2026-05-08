using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

        // Customize data labels to show both category name and value
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        try
        {
            pres.Save("CustomDataLabel.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}