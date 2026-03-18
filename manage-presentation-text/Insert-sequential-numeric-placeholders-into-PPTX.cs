using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SequentialPlaceholdersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Number of slides to create
                int slideCount = 5;

                for (int i = 1; i <= slideCount; i++)
                {
                    // Use the first layout slide as a template
                    Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides[0];

                    // Add a new empty slide based on the layout
                    Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(layout);

                    // Add a rectangle shape that will act as a placeholder
                    Aspose.Slides.IAutoShape placeholder = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        50f,   // X position
                        100f,  // Y position
                        400f,  // Width
                        50f    // Height
                    );

                    // Set solid fill color for visibility
                    placeholder.FillFormat.FillType = FillType.Solid;
                    placeholder.FillFormat.SolidFillColor.Color = Color.LightGray;

                    // Add text indicating the placeholder number
                    placeholder.AddTextFrame("Placeholder " + i);
                }

                // Save the presentation before exiting
                presentation.Save("SequentialPlaceholders.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}