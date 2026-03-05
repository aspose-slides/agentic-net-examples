using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the source presentation containing the slide to be merged
            Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("Source.pptx");

            // Load the destination presentation where the slide will be inserted
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation("Destination.pptx");

            // Choose the slide from the source presentation (e.g., the first slide)
            Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];

            // Insert a clone of the source slide into the destination at the desired index (e.g., position 1)
            Aspose.Slides.ISlide insertedSlide = destPres.Slides.InsertClone(1, sourceSlide);

            // Save the merged presentation to disk
            destPres.Save("MergedOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            sourcePres.Dispose();
            destPres.Dispose();
        }
    }
}