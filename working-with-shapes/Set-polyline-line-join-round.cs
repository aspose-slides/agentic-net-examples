using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape (used here as a complex polyline placeholder)
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

            // Set shape fill to solid white
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.White;

            // Configure line format
            shape.LineFormat.Width = 5;
            shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
            shape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
            shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Set line join style to round
            shape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Round;

            // Save the presentation
            string outputPath = "JoinStyleRound.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}