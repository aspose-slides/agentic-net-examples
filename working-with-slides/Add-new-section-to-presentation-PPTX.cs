using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                Presentation presentation = new Presentation(inputPath);

                // Get the first slide to start the new section
                ISlide firstSlide = presentation.Slides[0];

                // Add a new section starting from the first slide
                ISection newSection = presentation.Sections.AddSection("New Section", firstSlide);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}