using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 450f, 300f);

        // Enable the data table
        chart.HasDataTable = true;

        // Get the data table object
        Aspose.Slides.Charts.IDataTable dataTable = chart.ChartDataTable;

        // Show borders
        dataTable.HasBorderHorizontal = true;
        dataTable.HasBorderVertical = true;

        // Format the border line
        dataTable.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        dataTable.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
        dataTable.Format.Line.Width = 2.0;

        // Save the presentation
        presentation.Save("FormattedDataTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}