using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Locate the second ZoomFrame in the presentation
                int zoomCounter = 0;
                IZoomFrame secondZoom = null;

                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        IZoomFrame zoom = shape as IZoomFrame;
                        if (zoom != null)
                        {
                            zoomCounter++;
                            if (zoomCounter == 2)
                            {
                                secondZoom = zoom;
                                break;
                            }
                        }
                    }
                    if (secondZoom != null)
                    {
                        break;
                    }
                }

                // Remove background from the second ZoomFrame if it exists
                if (secondZoom != null)
                {
                    secondZoom.ShowBackground = false;
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}