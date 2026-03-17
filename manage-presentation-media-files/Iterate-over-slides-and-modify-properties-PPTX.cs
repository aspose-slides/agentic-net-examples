using System;
using Aspose.Slides.Export;

namespace PresentationTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        Console.WriteLine("Slide Number: " + slide.SlideNumber);
                    }

                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}