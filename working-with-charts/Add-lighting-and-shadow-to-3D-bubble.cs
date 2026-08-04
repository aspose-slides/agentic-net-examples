// -----------------------------------------------------------------------------
// Example: Add lighting and shadow to a 3‑D bubble chart using C#
//
// Description:
// Demonstrates how to create a 3‑D bubble chart, configure custom lighting,
// and apply an outer shadow effect using Aspose.Slides for .NET. The example
// shows the necessary steps to build a presentation, add a bubble chart,
// adjust bubble size representation, set camera and light rig, and save the
// result as a PPTX file in a console application.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, 3D bubble chart, Lighting,
// Shadow, Chart formatting, Presentation automation
//
// Use Cases:
// - Generate PowerPoint presentations with 3‑D bubble charts.
// - Apply custom lighting and shadow effects to charts programmatically.
// - Automate chart styling in .NET applications.
// - Create reusable code for presentation processing and visual enhancements.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a 3‑D bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

        // Set bubble size representation to Width and increase the scale
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // 150 % of default size

        // Configure custom lighting for a realistic 3‑D appearance
        chart.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        chart.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
        chart.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Apply an outer shadow effect to the chart
        chart.EffectFormat.EnableOuterShadowEffect();
        chart.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
        chart.EffectFormat.OuterShadowEffect.Distance = 3.0;
        chart.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(0, 0, 0);

        // Save the presentation before exiting
        presentation.Save("3D_Bubble_Chart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
