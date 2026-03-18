using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "source.pptx";
            string outputPath = "output.pptx";

            using (Presentation pres = new Presentation(sourcePath))
            {
                // Access the slides collection
                ISlideCollection slides = pres.Slides;

                // Select the slide to clone (e.g., first slide)
                ISlide sourceSlide = slides[0];

                // Clone the selected slide to the end of the collection
                ISlide clonedSlide = slides.AddClone(sourceSlide);

                // The cloned slide can be edited here if needed

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}