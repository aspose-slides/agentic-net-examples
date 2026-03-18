using System;
using System.Drawing;
using Aspose.Slides.Export;

namespace HighlightExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Apply highlight to the specified text
                presentation.HighlightText("Important", System.Drawing.Color.Yellow);

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}