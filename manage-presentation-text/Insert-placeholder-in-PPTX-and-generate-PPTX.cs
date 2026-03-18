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
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Replace placeholder text with new text
                Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "[Placeholder]", "New Text", null);
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}