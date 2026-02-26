using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Sample text");

            // Define a portion format with the desired font size
            Aspose.Slides.PortionFormat format = new Aspose.Slides.PortionFormat();
            format.FontHeight = 24f; // Set font size to 24 points

            // Apply the format to the specific text portion
            Aspose.Slides.Util.SlideUtil.FindAndReplaceText(
                pres, true, "Sample text", "Sample text", format);

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}