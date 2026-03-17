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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = shapes[shapeIndex];
                        Aspose.Slides.ISummaryZoomFrame zoomFrame = shape as Aspose.Slides.ISummaryZoomFrame;

                        // Apply formatting if the shape is a Summary Zoom frame
                        if (zoomFrame != null)
                        {
                            zoomFrame.X = 150f;
                            zoomFrame.Y = 20f;
                            zoomFrame.Width = 500f;
                            zoomFrame.Height = 250f;
                            zoomFrame.Name = "SummaryZoom";
                            zoomFrame.AlternativeText = "Summary Zoom Frame";
                            zoomFrame.IsDecorative = false;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}