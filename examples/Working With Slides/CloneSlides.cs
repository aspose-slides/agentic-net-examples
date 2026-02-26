using System;

class Program
{
    static void Main()
    {
        // Load the source presentation
        using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("source.pptx"))
        {
            // Create a new destination presentation
            using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
            {
                // Get slide collections
                Aspose.Slides.ISlideCollection sourceSlides = sourcePres.Slides;
                Aspose.Slides.ISlideCollection destSlides = destPres.Slides;

                // Clone each slide from source to destination
                for (int i = 0; i < sourceSlides.Count; i++)
                {
                    Aspose.Slides.ISlide sourceSlide = sourceSlides[i];
                    destSlides.AddClone(sourceSlide);
                }

                // Save the destination presentation
                destPres.Save("cloned_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}