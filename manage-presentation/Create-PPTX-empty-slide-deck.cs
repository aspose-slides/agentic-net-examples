using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                // The presentation is initialized with one empty slide.
                // Additional slide manipulation can be performed here.

                presentation.Save("EmptyPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}