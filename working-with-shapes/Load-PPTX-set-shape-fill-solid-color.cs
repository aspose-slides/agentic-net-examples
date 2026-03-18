using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Access the first shape on the slide
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Apply a solid fill color to the shape
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.Blue;

                // Adjust the shape's line width
                shape.LineFormat.Width = 5.0f;

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}