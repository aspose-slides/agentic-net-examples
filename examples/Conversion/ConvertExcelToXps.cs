class Program
{
    static void Main()
    {
        // Define input and output paths
        System.String dataDir = "Data";
        System.String excelPath = System.IO.Path.Combine(dataDir, "input.xlsx");
        System.String outputPath = System.IO.Path.Combine(dataDir, "output.xps");

        // Load the Excel workbook
        Aspose.Slides.Excel.ExcelDataWorkbook workbook = new Aspose.Slides.Excel.ExcelDataWorkbook(excelPath);

        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get a blank layout slide
            Aspose.Slides.ILayoutSlide blankLayout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

            // Add an empty slide based on the blank layout
            Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(blankLayout);

            // Add a chart from the Excel workbook (first chart in Sheet1)
            Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                slide.Shapes,
                0f,
                0f,
                workbook,
                "Sheet1",
                0,
                false);

            // Save the presentation as XPS
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
        }
    }
}