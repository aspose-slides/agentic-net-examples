using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load presentation with a default regular font to be used as fallback for missing characters
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions(Aspose.Slides.LoadFormat.Auto);
            loadOptions.DefaultRegularFont = "Arial";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions))
            {
                // Set fallback font for saving (HTML5 export in this example)
                Aspose.Slides.Export.Html5Options htmlOptions = new Aspose.Slides.Export.Html5Options();
                htmlOptions.DefaultRegularFont = "Arial";

                // Save the presentation; fallback font ensures missing characters are displayed correctly
                presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html5, htmlOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}