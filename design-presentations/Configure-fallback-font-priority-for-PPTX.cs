using System;
using Aspose.Slides.Export;

namespace FallbackFontDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var loadOptions = new Aspose.Slides.LoadOptions(Aspose.Slides.LoadFormat.Auto);
                loadOptions.DefaultRegularFont = "Arial";

                using (var presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions))
                {
                    var saveOptions = new Aspose.Slides.Export.PptxOptions();
                    saveOptions.DefaultRegularFont = "Arial";

                    presentation.Save("output.pptx", SaveFormat.Pptx, saveOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}