using System;

namespace ChangeCategoryAxisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file name
            string dataDir = "C:\\Temp\\";
            string outputFileName = "ChangedCategoryAxis.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Cast the first shape to IChart (should be the chart we just added)
            Aspose.Slides.Charts.IChart chartFromShape = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;

            if (chartFromShape != null)
            {
                chartFromShape.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;
                chartFromShape.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
                chartFromShape.Axes.HorizontalAxis.MajorUnit = 1.0;
                chartFromShape.Axes.HorizontalAxis.MajorUnitScale = Aspose.Slides.Charts.TimeUnitType.Months;
            }

            // Save the presentation
            presentation.Save(dataDir + outputFileName, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}