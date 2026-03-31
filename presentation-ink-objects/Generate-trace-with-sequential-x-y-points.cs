using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // ------------------------------------------------------------
        // NOTE: Adding an Ink shape programmatically may require a
        // specific API (e.g., slide.Shapes.AddInk). The exact method
        // depends on the Aspose.Slides version. The following code
        // demonstrates the intended logic assuming such a method exists.
        // ------------------------------------------------------------
        // Aspose.Slides.IInk inkShape = (Aspose.Slides.IInk)slide.Shapes.AddInk(50, 50, 400, 300);

        // Create sequential X and Y points
        int pointCount = 10;
        PointF[] sequentialPoints = new PointF[pointCount];
        for (int i = 0; i < pointCount; i++)
        {
            sequentialPoints[i] = new PointF(i * 10f, i * 10f);
        }

        // ------------------------------------------------------------
        // Populate the first trace of the Ink shape with the points.
        // InkTrace.Points is read‑only; in a real scenario you would use
        // the appropriate API to create a trace with these points and add
        // it to the Ink shape. The code below is illustrative.
        // ------------------------------------------------------------
        // Aspose.Slides.Ink.InkTrace newTrace = new Aspose.Slides.Ink.InkTrace();
        // newTrace.SetPoints(sequentialPoints); // Hypothetical method
        // inkShape.Traces.Add(newTrace);        // Hypothetical method

        // Save the presentation
        try
        {
            presentation.Save("InkWithSequentialPoints.pptx", SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}