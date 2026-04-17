using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesInkExample
{
    class Program
    {
        static void Main()
        {
            // Define output file path
            string outputPath = "InkShape.pptx";

            // Delete the file if it already exists
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line shape to emulate an ink trace
            Aspose.Slides.IAutoShape inkShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Line,
                50f,   // X position
                150f,  // Y position
                300f,  // Width
                0f);   // Height (line)

            // Apply scribble sketch effect to emulate ink
            inkShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

            // Set the line (ink) color to red
            inkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            inkShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

            // Save the presentation with exception handling for unsupported formats
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle accordingly (e.g., log or inform the user)
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}