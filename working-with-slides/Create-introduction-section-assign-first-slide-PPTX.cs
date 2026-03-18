using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Add a new section named "Introduction" starting from the first slide
                Aspose.Slides.ISection section = presentation.Sections.AddSection("Introduction", presentation.Slides[0]);

                // Save the presentation to a PPTX file
                presentation.Save("IntroductionSection.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}