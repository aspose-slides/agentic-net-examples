using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "SetChartDataSource.pptx";
        string workbookPath = "Data.xlsx";

        // Verify that the Excel workbook exists
        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook file not found: " + workbookPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];

                // Add a chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Link the chart to the external workbook and load its data
                ((ChartData)chart.ChartData).SetExternalWorkbook(workbookPath, true);

                // Set the chart's data source to a named range defined in the workbook
                ((ChartData)chart.ChartData).SetRange("Sheet1!MyData");

                // Save the presentation
                pres.Save(presentationPath, SaveFormat.Pptx);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Argument error: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Invalid operation: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}