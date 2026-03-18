using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ChangeFontColorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                LoadOptions loadOptions = new LoadOptions();
                Presentation presentation = new Presentation("input.pptx", loadOptions);

                // Define the format with red font color
                PortionFormat format = new PortionFormat();
                format.FillFormat.FillType = FillType.Solid;
                format.FillFormat.SolidFillColor.Color = Color.Red;

                // Change font color of the selected text (replace with same text to apply format)
                string findText = "Sample Text"; // text to find
                SlideUtil.FindAndReplaceText(presentation, true, findText, findText, format);

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}