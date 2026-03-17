using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define load options with a fallback regular font
            LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
            loadOptions.DefaultRegularFont = "Arial";

            // Load the presentation using the load options
            using (Presentation presentation = new Presentation("input.pptx", loadOptions))
            {
                // Define save options with a fallback regular font
                PptxOptions saveOptions = new PptxOptions();
                saveOptions.DefaultRegularFont = "Arial";

                // Save the presentation with the specified options
                presentation.Save("output.pptx", SaveFormat.Pptx, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}