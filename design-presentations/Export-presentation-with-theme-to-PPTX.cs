using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access and modify the master theme
            Aspose.Slides.Theme.IMasterTheme masterTheme = presentation.MasterTheme;
            masterTheme.Name = "CustomTheme";

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a title shape to the slide
            Aspose.Slides.IAutoShape titleShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
            titleShape.AddTextFrame("Themed Presentation");
            titleShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 48;

            // Save the presentation as PPTX
            presentation.Save("ThemedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}