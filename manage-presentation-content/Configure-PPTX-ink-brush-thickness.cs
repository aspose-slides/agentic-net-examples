using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is an Ink shape
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Cast the shape to Ink
            Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;

            if (inkShape != null && inkShape.Traces.Length > 0)
            {
                // Get the brush of the first ink trace
                Aspose.Slides.Ink.IInkBrush brush = inkShape.Traces[0].Brush;

                // Set the brush size (width and height in points)
                brush.Size = new System.Drawing.SizeF(5f, 5f);
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}