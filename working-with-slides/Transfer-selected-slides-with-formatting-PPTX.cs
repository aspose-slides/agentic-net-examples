using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to source and destination presentations
            var sourcePath = "source.pptx";
            var destinationPath = "destination.pptx";

            // Load source presentation and create a new destination presentation
            using (var sourcePresentation = new Aspose.Slides.Presentation(sourcePath))
            using (var destinationPresentation = new Aspose.Slides.Presentation())
            {
                // Indices of slides to duplicate (zero‑based)
                var slideIndices = new int[] { 0, 2 };

                // Clone each selected slide into the destination presentation
                foreach (var index in slideIndices)
                {
                    var insertPosition = destinationPresentation.Slides.Count;
                    destinationPresentation.Slides.InsertClone(insertPosition, sourcePresentation.Slides[index]);
                }

                // Save the resulting presentation
                destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}