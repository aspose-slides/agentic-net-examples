using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation("input.pptx");

            var sections = presentation.Sections;
            var targetSectionName = "Section to Remove";

            for (int i = 0; i < sections.Count; i++)
            {
                var section = sections[i];
                if (section.Name == targetSectionName)
                {
                    sections.RemoveSectionWithSlides(section);
                    break;
                }
            }

            presentation.Save("output.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}