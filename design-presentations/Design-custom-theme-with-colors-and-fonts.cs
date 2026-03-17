using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Modify master theme colors
            // Change first line style color to Red
            presentation.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
            // Change third fill style to solid green
            presentation.MasterTheme.FormatScheme.FillStyles[2].FillType = Aspose.Slides.FillType.Solid;
            presentation.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

            // Add a new slide using the first layout slide
            ILayoutSlide layoutSlide = presentation.LayoutSlides[0];
            ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

            // Add a title shape with custom font
            IAutoShape titleShape = (IAutoShape)newSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
            titleShape.AddTextFrame("Custom Themed Presentation");
            IParagraph paragraph = titleShape.TextFrame.Paragraphs[0];
            IPortion portion = paragraph.Portions[0];
            portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Calibri");
            portion.PortionFormat.FontHeight = 36;

            // Save the presentation
            presentation.Save("CustomThemePresentation.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}