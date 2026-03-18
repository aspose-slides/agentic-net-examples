using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing PPTX file
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                // Add a rectangle shape to the slide
                Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                // Configure the border (line) thickness
                rectangle.LineFormat.Width = 5;
                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}