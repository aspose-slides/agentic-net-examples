using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePresentationsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file paths
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            string sourcePath1 = Path.Combine(dataDir, "source1.pptx");
            string sourcePath2 = Path.Combine(dataDir, "source2.pptx");
            string outputPath = Path.Combine(dataDir, "merged_output.pptx");

            // Load source presentations
            Presentation sourcePres1 = new Presentation(sourcePath1);
            Presentation sourcePres2 = new Presentation(sourcePath2);

            // Create a new destination presentation
            Presentation destPres = new Presentation();

            // Get the slide collection of the destination presentation
            ISlideCollection destSlides = destPres.Slides;

            // Insert all slides from the first source presentation at the end of the destination
            for (int i = 0; i < sourcePres1.Slides.Count; i++)
            {
                // InsertClone inserts a copy of the source slide at the specified index
                destSlides.InsertClone(destSlides.Count, sourcePres1.Slides[i]);
            }

            // Insert all slides from the second source presentation at the end of the destination
            for (int i = 0; i < sourcePres2.Slides.Count; i++)
            {
                destSlides.InsertClone(destSlides.Count, sourcePres2.Slides[i]);
            }

            // Save the merged presentation
            destPres.Save(outputPath, SaveFormat.Pptx);

            // Clean up resources
            sourcePres1.Dispose();
            sourcePres2.Dispose();
            destPres.Dispose();
        }
    }
}