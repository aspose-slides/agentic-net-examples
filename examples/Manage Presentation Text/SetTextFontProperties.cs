using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Define the source font to be replaced and the new font
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
        Aspose.Slides.IFontData destinationFont = new Aspose.Slides.FontData("Times New Roman");

        // Replace the source font with the destination font throughout the presentation
        presentation.FontsManager.ReplaceFont(sourceFont, destinationFont);

        // Save the updated presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}