// -----------------------------------------------------------------------------
// Example: Rotate chart title by 45 degrees using C#
//
// Description:
// Demonstrates how to rotate a chart title by 45 degrees using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rotate, Chart, Title, Degrees, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate rotate chart title by 45 degrees.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



        // Access the first slide

        Aspose.Slides.ISlide slide = presentation.Slides[0];



        // Add a clustered column chart

        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(

            Aspose.Slides.Charts.ChartType.ClusteredColumn,

            50f, 50f, 450f, 300f);



        // Enable and set the chart title

        chart.HasTitle = true;

        chart.ChartTitle.AddTextFrameForOverriding("Sales Overview");



        // Rotate the chart title text by 45 degrees

        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.RotationAngle = 45f;



        // Save the presentation (handle unsupported format exception)

        try

        {

            presentation.Save("RotatedChartTitle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (Exception)

        {

            // Format not supported

        }



        // Dispose the presentation

        presentation.Dispose();

    }

}
