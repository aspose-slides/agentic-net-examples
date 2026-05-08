using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ChartDataTableBoldHeader.pptx";

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);
        chart.HasDataTable = true;

        // Apply bold style to the header row of the data table
        chart.ChartDataTable.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}