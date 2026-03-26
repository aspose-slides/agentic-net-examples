using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Paths for input and output files
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists; otherwise create a new one
        Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Presentation(inputPath);
        }
        else
        {
            presentation = new Presentation();
        }

        // Use the first slide (a new presentation always contains at least one slide)
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // ----- Custom formatting for the vertical axis -----
        IAxis verticalAxis = chart.Axes.VerticalAxis;
        // Set a custom number format for the axis labels
        verticalAxis.NumberFormat = "#,##0\" units\"";
        // Show values in millions
        verticalAxis.DisplayUnit = DisplayUnitType.Millions;

        // ----- Custom formatting for the horizontal axis -----
        IAxis horizontalAxis = chart.Axes.HorizontalAxis;
        // Adjust the distance of the category labels from the axis (value between 0 and 1000%)
        horizontalAxis.LabelOffset = 200; // Example: 20% offset

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}