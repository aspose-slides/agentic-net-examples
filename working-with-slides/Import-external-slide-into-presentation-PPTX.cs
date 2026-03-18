using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation mainPres = new Presentation())
            {
                // Load the external presentation
                using (Presentation externalPres = new Presentation("External.pptx"))
                {
                    // Get the first slide from the external presentation
                    Aspose.Slides.ISlide sourceSlide = externalPres.Slides[0];
                    // Insert the slide at the end of the main presentation
                    int insertIndex = mainPres.Slides.Count;
                    mainPres.Slides.InsertClone(insertIndex, sourceSlide);
                }

                // Save the combined presentation
                mainPres.Save("CombinedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}