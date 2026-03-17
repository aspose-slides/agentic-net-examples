using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontSubstitutionExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Configure automatic font substitution by specifying a default regular font
                    PptxOptions saveOptions = new PptxOptions();
                    saveOptions.DefaultRegularFont = "Arial";

                    // Save the presentation with the substitution options
                    presentation.Save("output.pptx", SaveFormat.Pptx, saveOptions);

                    // Display the font substitution information
                    foreach (FontSubstitutionInfo info in presentation.FontsManager.GetSubstitutions())
                    {
                        Console.WriteLine($"{info.OriginalFontName} -> {info.SubstitutedFontName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}