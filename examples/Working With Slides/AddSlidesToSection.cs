using System;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the input and output presentations
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Load the existing presentation
        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the first existing section (assumes at least one section exists)
            var targetSection = presentation.Sections[0]; // ISection

            // Choose a slide to clone (e.g., the first slide in the presentation)
            var sourceSlide = presentation.Slides[0]; // ISlide

            // Add a cloned slide to the target section
            var clonedSlide1 = presentation.Slides.AddClone(sourceSlide, targetSection); // ISlide

            // Add another cloned slide to the same section
            var clonedSlide2 = presentation.Slides.AddClone(sourceSlide, targetSection); // ISlide

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}