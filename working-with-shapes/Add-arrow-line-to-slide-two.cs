// -----------------------------------------------------------------------------
// Example: Add arrow line to slide two using C#
//
// Description:
// Demonstrates how to add an arrow line to the second slide of a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a second slide, inserts a line shape with customized
// line style, width, dash pattern, arrowheads, and color, and saves the result
// as a PPTX file. This pattern can be used to automate drawing shapes with
// arrows in presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Arrow, Line, Slide, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add arrowed lines to specific slides.
// - Build C# utilities for PowerPoint diagram creation.
// - Generate or modify PPTX files with custom shapes in .NET applications.
// - Automate visual annotations in presentation workflows.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ArrowLine.pptx";
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)secondSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);
        line.LineFormat.Style = Aspose.Slides.LineStyle.ThickBetweenThin;
        line.LineFormat.Width = 10;
        line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
        line.LineFormat.BeginArrowheadLength = Aspose.Slides.LineArrowheadLength.Short;
        line.LineFormat.BeginArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Oval;
        line.LineFormat.EndArrowheadLength = Aspose.Slides.LineArrowheadLength.Long;
        line.LineFormat.EndArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Triangle;
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
