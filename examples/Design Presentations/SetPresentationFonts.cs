using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Define the source font to be replaced and the destination font
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
        Aspose.Slides.IFontData destinationFont = new Aspose.Slides.FontData("Calibri");

        // Replace the source font with the destination font throughout the presentation
        presentation.FontsManager.ReplaceFont(sourceFont, destinationFont);

        // Save the modified presentation
        presentation.Save("FontReplaced.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}