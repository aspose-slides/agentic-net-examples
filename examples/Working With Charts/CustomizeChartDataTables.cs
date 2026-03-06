using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomizeChartDataTables
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomizeChartDataTable_out.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 450f, 300f);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Access the chart's data table
            Aspose.Slides.Charts.IDataTable dataTable = chart.ChartDataTable;

            // Customize border visibility
            dataTable.HasBorderHorizontal = true; // Show horizontal borders
            dataTable.HasBorderVertical = true;   // Show vertical borders
            dataTable.HasBorderOutline = true;    // Show outline border

            // Optionally show the legend key in the data table
            dataTable.ShowLegendKey = true;

            // Save the presentation
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}