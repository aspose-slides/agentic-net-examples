using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Define dash styles and colors for each slide
                Aspose.Slides.LineDashStyle[] dashStyles = new Aspose.Slides.LineDashStyle[]
                {
                    Aspose.Slides.LineDashStyle.Solid,
                    Aspose.Slides.LineDashStyle.Dash,
                    Aspose.Slides.LineDashStyle.Dot,
                    Aspose.Slides.LineDashStyle.DashDot,
                    Aspose.Slides.LineDashStyle.LargeDash
                };

                Color[] colors = new Color[]
                {
                    Color.Red,
                    Color.Green,
                    Color.Blue,
                    Color.Orange,
                    Color.Purple
                };

                // Ensure the presentation has enough slides
                for (int i = 0; i < dashStyles.Length; i++)
                {
                    Aspose.Slides.ISlide slide;
                    if (i == 0)
                    {
                        // Use the default first slide
                        slide = presentation.Slides[0];
                    }
                    else
                    {
                        // Add a new empty slide using the layout of the first slide
                        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                    }

                    // Add a line shape to the slide
                    Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Line,
                        50,   // X position
                        150,  // Y position
                        300,  // Width
                        0);   // Height (0 for a straight line)

                    // Set dash style
                    lineShape.LineFormat.DashStyle = dashStyles[i];

                    // Set line color
                    lineShape.LineFormat.FillFormat.SolidFillColor.Color = colors[i];
                }

                // Define output path
                string outputPath = "LineDashStylesPresentation.pptx";

                // Save the presentation
                try
                {
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}