using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupUngroupShapesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and ensure it exists
            string outputDir = "output" + Path.DirectorySeparatorChar;
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide and its shape collection
            ISlide slide = pres.Slides[0];
            IShapeCollection slideShapes = slide.Shapes;

            // Add a group shape to the slide
            IGroupShape group = slideShapes.AddGroupShape();

            // Add four rectangle shapes inside the group
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 100);
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 250, 100, 100, 100);
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 250, 100, 100);
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 250, 250, 100, 100);

            // Set the frame of the group shape
            group.Frame = new ShapeFrame(50, 50, 400, 400, NullableBool.False, NullableBool.False, 0);

            // ----- Ungrouping demonstration -----
            // Clone each shape inside the group back to the slide
            IShape[] innerShapes = group.Shapes.ToArray();
            foreach (IShape innerShape in innerShapes)
            {
                slideShapes.AddClone(innerShape);
            }

            // Remove the original group shape from the slide
            slideShapes.Remove(group);
            // ------------------------------------

            // Save the presentation
            pres.Save(outputDir + "GroupUngroupShapes_out.pptx", SaveFormat.Pptx);
        }
    }
}