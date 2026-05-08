using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine whether to show the data table from the first command‑line argument
        bool showDataTable = false;
        if (args.Length > 0)
        {
            bool parsed;
            if (bool.TryParse(args[0], out parsed))
            {
                showDataTable = parsed;
            }
        }

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Toggle the data table visibility based on the parameter
        chart.HasDataTable = showDataTable;

        // Save the presentation
        string outputPath = "ToggleDataTable.pptx";
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}