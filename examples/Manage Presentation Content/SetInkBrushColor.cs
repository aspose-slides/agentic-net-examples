using System;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Load the existing PPTX presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Cast the first shape to an Ink object
        Aspose.Slides.Ink.IInk ink = slide.Shapes[0] as Aspose.Slides.Ink.IInk;

        if (ink != null)
        {
            // Retrieve all ink traces
            Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;

            if (traces != null && traces.Length > 0)
            {
                // Get the brush of the first trace
                Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;

                // Set the brush color to Red
                brush.Color = Color.Red;
            }
        }

        // Save the modified presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}