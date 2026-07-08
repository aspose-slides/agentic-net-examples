using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];
            // Add a group shape to the slide
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();
            // Lock the group shape to prevent adding new shapes
            groupShape.GroupShapeLock.GroupingLocked = true;
            // Attempt to add a new shape to the locked group and catch the exception
            try
            {
                groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
            }
            catch (Exception ex)
            {
                // Handle the exception when adding a shape to a locked group
                Console.WriteLine("Exception caught: " + ex.Message);
            }
            // Save the presentation
            string outputPath = "GroupShapeLocked_out.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            // Dispose the presentation
            pres.Dispose();
        }
    }
}