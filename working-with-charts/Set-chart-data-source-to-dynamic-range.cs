using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Paths for the output presentation and the source Excel workbook
        string presentationPath = "DynamicChart.pptx";
        string workbookPath = "Data.xlsx";

        // Verify that the Excel workbook exists before proceeding
        if (!File.Exists(workbookPath))
        {
            Console.WriteLine("Workbook file not found: " + workbookPath);
            return;
        }

        try
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a chart without initializing sample data (initWithSample = false)
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f, false);

                // Obtain the chart data object
                IChartData chartData = chart.ChartData;

                // Set the external workbook as the data source and load its data immediately
                ((ChartData)chartData).SetExternalWorkbook(workbookPath, true);

                // Define a dynamic range that can expand (e.g., up to row 1000)
                string dynamicRange = "Sheet1!$A$1:$B$1000";

                // Apply the dynamic range to the chart; series and categories will update accordingly
                ((ChartData)chartData).SetRange(dynamicRange);

                // Save the presentation to disk
                pres.Save(presentationPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + presentationPath);
            }
        }
        catch (ArgumentException ex)
        {
            // Handles errors such as incorrect range format or invalid arguments
            Console.WriteLine("Argument error: " + ex.Message);
        }
        catch (IOException ex)
        {
            // Handles file I/O related errors
            Console.WriteLine("IO error: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handles any other unexpected errors
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}