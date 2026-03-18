using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Adjust category axis label offset (ushort)
            chart.Axes.HorizontalAxis.LabelOffset = (ushort)50;

            // Set tick label spacing (uint)
            chart.Axes.HorizontalAxis.TickLabelSpacing = 2u;

            // Set tick marks spacing (uint)
            chart.Axes.HorizontalAxis.TickMarksSpacing = 1u;

            // Define category axis type as Date
            chart.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;

            // Set base unit scale for date axis
            chart.Axes.HorizontalAxis.BaseUnitScale = Aspose.Slides.Charts.TimeUnitType.Months;

            // Set display unit for value axis to Millions
            chart.Axes.VerticalAxis.DisplayUnit = Aspose.Slides.Charts.DisplayUnitType.Millions;

            // Save the presentation
            presentation.Save("UpdatedCategoryAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}