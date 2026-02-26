using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontReplacementDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Presentation presentation = new Presentation("input.pptx");

            // Define source and destination fonts
            IFontData sourceFont = new FontData("Arial");
            IFontData destinationFont = new FontData("Times New Roman");

            // Replace the source font with the destination font throughout the presentation
            presentation.FontsManager.ReplaceFont(sourceFont, destinationFont);

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}