using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddRoundedRectangleSlideThreeSolidFill
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Ensure there are at least three slides
            while (pres.Slides.Count < 3)
            {
                // Add an empty slide using the layout of the first slide
                pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            }

            // Get the third slide (zero‑based index 2)
            Aspose.Slides.ISlide slide = pres.Slides[2];

            // Add a rounded rectangle shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.RoundCornerRectangle,
                100f,   // X position
                100f,   // Y position
                300f,   // Width
                150f);  // Height

            // Set solid fill (blue color)
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Blue;

            // Adjust the corner radius to 10 points
            // The first adjustment for a round‑corner rectangle corresponds to the radius
            if (shape.Adjustments.Count > 0)
            {
                shape.Adjustments[0].AngleValue = 10f;
            }

            // Save the presentation
            try
            {
                pres.Save("RoundedRectangleSlide3.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                // Format not supported: ex.Message
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}