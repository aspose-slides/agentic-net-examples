using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                // Add a new empty slide based on the layout of the first slide
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                // Save the presentation in PPTX format
                presentation.Save("EditedPresentation.pptx", SaveFormat.Pptx);
                // Export the same presentation as PDF
                presentation.Save("EditedPresentation.pdf", SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}