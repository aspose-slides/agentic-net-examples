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

            // Retrieve the existing fallback rules collection
            IFontFallBackRulesCollection rules = presentation.FontsManager.FontFallBackRulesCollection;

            // Add a fallback rule for a Unicode range to use Times New Roman
            FontFallBackRule fallbackRule = new FontFallBackRule(0x400, 0x4FF, "Times New Roman");
            rules.Add(fallbackRule);

            // Assign the modified collection back to the FontsManager (optional)
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            presentation.Save("FallbackFontPresentation.pptx", SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}