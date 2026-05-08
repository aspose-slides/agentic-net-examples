using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Access the first data point's label
        Aspose.Slides.Charts.IDataLabel label = chart.ChartData.Series[0].DataPoints[0].Label;

        // Set the label background to a semi‑transparent yellow
        label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 255, 255, 0);

        // Save the presentation
        presentation.Save("ChartWithSemiTransparentLabel.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}