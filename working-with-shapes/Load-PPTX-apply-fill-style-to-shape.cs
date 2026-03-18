using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Ensure there is at least one shape on the slide
                if (slide.Shapes.Count > 0)
                {
                    // Get the first shape
                    IShape shape = slide.Shapes[0];

                    // Apply a solid fill style if the shape supports filling
                    if (shape.FillFormat != null)
                    {
                        shape.FillFormat.FillType = FillType.Solid;
                        shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}