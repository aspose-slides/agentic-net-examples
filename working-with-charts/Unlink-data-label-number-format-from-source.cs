using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (created by default)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 400);

        // Unlink data label number format from source data
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;

        // Optionally set a custom number format for the data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

        // Save the presentation
        presentation.Save("UnlinkedDataLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}