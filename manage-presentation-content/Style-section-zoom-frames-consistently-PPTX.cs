using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.ISectionZoomFrame sectionZoom = shape as Aspose.Slides.ISectionZoomFrame;

                        if (sectionZoom != null)
                        {
                            // Apply consistent fill color
                            if (sectionZoom.FillFormat != null)
                            {
                                sectionZoom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                sectionZoom.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;
                            }

                            // Apply consistent line formatting
                            if (sectionZoom.LineFormat != null && sectionZoom.LineFormat.FillFormat != null)
                            {
                                sectionZoom.LineFormat.Width = 2.0f;
                                sectionZoom.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                sectionZoom.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkBlue;
                            }

                            // Set alternative text for accessibility
                            sectionZoom.AlternativeText = "Section Zoom";
                            sectionZoom.AlternativeTextTitle = "Section Zoom Title";

                            // Ensure background is displayed during zoom
                            sectionZoom.ShowBackground = true;

                            // Set transition duration between zoom and target slides
                            sectionZoom.TransitionDuration = 1.0f;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}