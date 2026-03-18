using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ReplacePlaceholderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Replace placeholder text "[PLACEHOLDER]" with "New Text"
                SlideUtil.FindAndReplaceText(presentation, true, "[PLACEHOLDER]", "New Text");

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}