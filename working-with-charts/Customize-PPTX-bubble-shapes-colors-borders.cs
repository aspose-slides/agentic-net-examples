using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add first bubble shape (ellipse) with solid fill and dark border
            Aspose.Slides.IAutoShape bubble1 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 50, 50, 100, 100);
            bubble1.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            bubble1.FillFormat.SolidFillColor.Color = Color.LightBlue;
            bubble1.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            bubble1.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
            bubble1.LineFormat.Width = 2;

            // Add second bubble with gradient fill and thicker border
            Aspose.Slides.IAutoShape bubble2 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 200, 50, 120, 120);
            bubble2.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            bubble2.FillFormat.GradientFormat.GradientStops.Add(0, Color.Yellow);
            bubble2.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
            bubble2.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            bubble2.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
            bubble2.LineFormat.Width = 3;

            // Add third bubble with pattern fill and thin border
            Aspose.Slides.IAutoShape bubble3 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 380, 50, 100, 100);
            bubble3.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
            bubble3.FillFormat.PatternFormat.ForeColor.Color = Color.Green;
            bubble3.FillFormat.PatternFormat.BackColor.Color = Color.White;
            bubble3.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
            bubble3.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            bubble3.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
            bubble3.LineFormat.Width = 1.5f;

            // Save the presentation
            presentation.Save("CustomBubbles.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}