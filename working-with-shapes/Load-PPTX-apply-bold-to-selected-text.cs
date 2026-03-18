using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            var loadOptions = new LoadOptions();
            loadOptions.DefaultRegularFont = "Arial";

            using (var presentation = new Presentation("input.pptx", loadOptions))
            {
                var format = new PortionFormat();
                format.FontBold = NullableBool.True;

                // Apply bold styling to the text "TargetText"
                SlideUtil.FindAndReplaceText(presentation, true, "TargetText", "TargetText", format);

                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}