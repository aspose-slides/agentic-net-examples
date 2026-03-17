using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Locate the second zoom frame in the first slide
            int zoomIndex = 0;
            Aspose.Slides.IZoomFrame secondZoom = null;
            foreach (Aspose.Slides.IShape shape in presentation.Slides[0].Shapes)
            {
                if (shape is Aspose.Slides.IZoomFrame)
                {
                    if (zoomIndex == 1)
                    {
                        secondZoom = (Aspose.Slides.IZoomFrame)shape;
                        break;
                    }
                    zoomIndex++;
                }
            }

            // Strip background if the second zoom frame exists
            if (secondZoom != null)
            {
                secondZoom.ShowBackground = false;
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}