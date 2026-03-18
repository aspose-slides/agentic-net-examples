using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define load options with a default regular font
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DefaultRegularFont = "Arial";

            // Create a new presentation using the load options
            using (Presentation presentation = new Presentation(loadOptions))
            {
                // Save the presentation as PPTX
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}