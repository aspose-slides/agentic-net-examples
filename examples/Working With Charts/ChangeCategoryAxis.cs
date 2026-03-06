using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 400f, 300f);

        // Change the category axis to a date axis and configure major unit
        chart.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;
        chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
        chart.Axes.HorizontalAxis.MajorUnit = 1.0;
        chart.Axes.HorizontalAxis.MajorUnitScale = Aspose.Slides.Charts.TimeUnitType.Months;

        // Save the presentation
        string outputPath = "ChangeCategoryAxis_out.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}