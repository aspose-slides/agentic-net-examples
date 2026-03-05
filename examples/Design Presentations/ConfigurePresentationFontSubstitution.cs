using System;

namespace FontSubstitutionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Define source and destination fonts
            Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
            Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Times New Roman");

            // Create a substitution rule
            Aspose.Slides.FontSubstRule substitutionRule = new Aspose.Slides.FontSubstRule(sourceFont, destFont);

            // Apply the substitution rule
            presentation.FontsManager.ReplaceFont(substitutionRule);

            // Save the presentation
            presentation.Save("FontSubstitutionOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}