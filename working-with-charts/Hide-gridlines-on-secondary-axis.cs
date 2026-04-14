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

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Plot the first series on the secondary vertical axis
        chart.ChartData.Series[0].PlotOnSecondAxis = true;

        // Hide major gridlines on the secondary vertical axis
        chart.Axes.SecondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

        // Hide minor gridlines on the secondary vertical axis
        chart.Axes.SecondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

        // Save the presentation
        pres.Save("HideSecondaryAxisGridlines.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}