using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Define dash styles and colors for each slide
        Aspose.Slides.LineDashStyle[] dashStyles = new Aspose.Slides.LineDashStyle[]
        {
            Aspose.Slides.LineDashStyle.Solid,
            Aspose.Slides.LineDashStyle.Dash,
            Aspose.Slides.LineDashStyle.Dot,
            Aspose.Slides.LineDashStyle.DashDot,
            Aspose.Slides.LineDashStyle.LargeDash
        };

        System.Drawing.Color[] colors = new System.Drawing.Color[]
        {
            System.Drawing.Color.Red,
            System.Drawing.Color.Green,
            System.Drawing.Color.Blue,
            System.Drawing.Color.Orange,
            System.Drawing.Color.Purple
        };

        int slideCount = dashStyles.Length;

        for (int i = 0; i < slideCount; i++)
        {
            Aspose.Slides.ISlide slide;
            if (i == 0)
            {
                // Use the default first slide
                slide = presentation.Slides[0];
            }
            else
            {
                // Add a new empty slide
                slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Add a line shape to the slide
            Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);
            line.LineFormat.Width = 5;
            line.LineFormat.DashStyle = dashStyles[i];
            line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            line.LineFormat.FillFormat.SolidFillColor.Color = colors[i];
        }

        // Save the presentation
        try
        {
            presentation.Save("UniqueLinesPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other save error
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}