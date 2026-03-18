using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation or create a new one
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Define the index where the new slide will be inserted
                int insertIndex = 1; // Insert after the first slide (0‑based)

                // Ensure there is at least one layout slide to use for the new slide
                Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides[0];

                // Insert an empty slide at the specified index using the chosen layout
                Aspose.Slides.ISlide newSlide = presentation.Slides.InsertEmptySlide(insertIndex, layout);

                // Optionally, add some content to the new slide (e.g., a title shape)
                newSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100).TextFrame.Text = "Inserted Slide";

                // Save the modified presentation
                presentation.Save("InsertedSlideOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}