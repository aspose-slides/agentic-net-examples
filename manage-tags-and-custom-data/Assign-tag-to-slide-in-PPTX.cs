using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AssignTagExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Access the first slide (index 0)
                ISlide slide = presentation.Slides[0];

                // Assign a custom tag to the slide
                slide.CustomData.Tags["Category"] = "Finance";

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