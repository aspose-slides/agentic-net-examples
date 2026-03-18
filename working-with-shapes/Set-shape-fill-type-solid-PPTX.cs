using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            // Get the first shape on the slide
            Aspose.Slides.IShape shape = slide.Shapes[0];
            // Set the shape's fill type to solid
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}