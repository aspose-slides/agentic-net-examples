using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions(Aspose.Slides.LoadFormat.Auto);
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx", loadOptions);

        // Define source and destination fonts
        Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Calibri");
        Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("Arial");

        // Create a font substitution rule
        Aspose.Slides.FontSubstRule substRule = new Aspose.Slides.FontSubstRule(sourceFont, destFont);

        // Apply the substitution rule to the presentation
        pres.FontsManager.ReplaceFont(substRule);

        // List font substitutions after replacement
        System.Collections.Generic.IEnumerable<Aspose.Slides.FontSubstitutionInfo> substitutions = pres.FontsManager.GetSubstitutions();
        foreach (Aspose.Slides.FontSubstitutionInfo info in substitutions)
        {
            Console.WriteLine("{0} -> {1}", info.OriginalFontName, info.SubstitutedFontName);
        }

        // Save the modified presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}