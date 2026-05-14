using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide (index zero)
            Aspose.Slides.ISlide firstSlide = pres.Slides[0];

            // Add a new section named "Introduction" starting from the first slide
            Aspose.Slides.ISection introSection = pres.Sections.AddSection("Introduction", firstSlide);

            // Verify the section was created
            if (pres.Sections.Count > 0 && pres.Sections[0].Name == "Introduction")
            {
                Console.WriteLine("Section 'Introduction' created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create section.");
            }

            // Save the presentation
            string outPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "IntroductionSection.pptx");
            try
            {
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported.
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}