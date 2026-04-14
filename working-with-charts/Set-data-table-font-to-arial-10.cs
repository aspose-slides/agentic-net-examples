using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Enable the data table
        chart.HasDataTable = true;

        // Set data table font to Arial, size 10 points
        chart.ChartDataTable.TextFormat.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");
        chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 10f;

        // Save the presentation
        try
        {
            pres.Save("DataTableFontArial.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        finally
        {
            pres.Dispose();
        }
    }
}