using System;
using Aspose.Slides;
using Aspose.Slides.Export;

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
                // Name of the section to delete
                var sectionName = "Section to Delete";

                // Locate the section by name
                Aspose.Slides.ISection targetSection = null;
                for (int i = 0; i < presentation.Sections.Count; i++)
                {
                    var sec = presentation.Sections[i];
                    if (sec.Name == sectionName)
                    {
                        targetSection = sec;
                        break;
                    }
                }

                if (targetSection != null)
                {
                    // Remove the section along with its slides
                    presentation.Sections.RemoveSectionWithSlides(targetSection);
                }
                else
                {
                    Console.WriteLine("Section not found.");
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}