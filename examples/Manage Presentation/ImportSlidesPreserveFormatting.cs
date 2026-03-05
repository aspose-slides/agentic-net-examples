using System;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("source.pptx");

        // Create a new destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Import each slide from the source while retaining its original formatting
        for (int i = 0; i < sourcePres.Slides.Count; i++)
        {
            Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[i];
            destPres.Slides.InsertClone(destPres.Slides.Count, sourceSlide);
        }

        // Save the merged presentation in PPTX format
        destPres.Save("merged.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        sourcePres.Dispose();
        destPres.Dispose();
    }
}