using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            int insertIndex = 1; // Desired insertion index

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Validate insertion index
                if (insertIndex < 0 || insertIndex > presentation.Slides.Count)
                {
                    insertIndex = presentation.Slides.Count;
                }

                // Insert a new empty slide at the specified index using the first layout slide
                Aspose.Slides.ISlide newSlide = presentation.Slides.InsertEmptySlide(insertIndex, presentation.LayoutSlides[0]);

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