using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing PPTX presentation
                Presentation presentation = new Presentation("input.pptx");

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a bent connector shape to the slide
                IConnector connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 0);

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

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