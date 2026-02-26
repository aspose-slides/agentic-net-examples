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

        // Customize the master theme: set the first line style's solid fill color to Red
        presentation.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

        // Save the presentation to a PPTX file
        presentation.Save("CustomThemePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}