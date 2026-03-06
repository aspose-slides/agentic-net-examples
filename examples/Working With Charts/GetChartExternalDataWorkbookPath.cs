class Program
{
    static void Main()
    {
        // Define input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Get the first shape as chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart != null)
        {
            // Check if chart uses external workbook
            Aspose.Slides.Charts.ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
            if (sourceType == Aspose.Slides.Charts.ChartDataSourceType.ExternalWorkbook)
            {
                // Retrieve external workbook path
                System.String externalPath = chart.ChartData.ExternalWorkbookPath;
                System.Console.WriteLine("External workbook path: " + externalPath);
            }
            else
            {
                System.Console.WriteLine("Chart does not use an external workbook.");
            }
        }
        else
        {
            System.Console.WriteLine("No chart found on the first slide.");
        }

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}