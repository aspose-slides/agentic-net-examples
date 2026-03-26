using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Numerical constants used across slides
        const double ConstantValue1 = 25.0;
        const double ConstantValue2 = 50.0;
        const double ConstantValue3 = 75.0;

        // Determine source file (if any) and load presentation
        string sourcePath = args.Length > 0 ? args[0] : null;
        Aspose.Slides.Presentation presentation;
        if (!string.IsNullOrEmpty(sourcePath) && File.Exists(sourcePath))
        {
            presentation = new Aspose.Slides.Presentation(sourcePath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Obtain a blank layout slide (required for adding new slides)
        Aspose.Slides.ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        if (blankLayout == null)
        {
            // If no blank layout exists, create one on the first master slide
            Aspose.Slides.IMasterSlide master = presentation.Masters[0];
            blankLayout = master.LayoutSlides.Add(SlideLayoutType.Blank, "BlankLayout");
        }

        // Add a new empty slide using the blank layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(blankLayout);

        // Add a clustered column chart to the new slide
        Aspose.Slides.Charts.IChart chart = newSlide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 400f, 300f);

        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add series
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Populate first series using defined constants
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, ConstantValue1));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, ConstantValue2));
        series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, ConstantValue3));

        // Populate second series using defined constants
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, ConstantValue3));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, ConstantValue1));
        series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, ConstantValue2));

        // Save the presentation
        string outputPath = "DefinedConstantsPresentation.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}