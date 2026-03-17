using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is an Ink object
                    Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                    if (inkShape != null)
                    {
                        // Access the ink traces
                        Aspose.Slides.Ink.IInkTrace[] traces = inkShape.Traces;
                        if (traces != null && traces.Length > 0)
                        {
                            // Get the brush of the first trace and set its color
                            Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;
                            brush.Color = System.Drawing.Color.Red;
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}