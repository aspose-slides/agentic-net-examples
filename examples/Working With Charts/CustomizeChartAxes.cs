using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Position the horizontal axis between categories
        chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

        // Set the distance of category axis labels from the axis (e.g., 200 = 20%)
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)200;

        // Save the presentation
        string outPath = "CustomizedAxes.pptx";
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}