using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "source.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            Presentation srcPres = new Presentation(inputPath);
            // Create a destination presentation
            Presentation destPres = new Presentation();

            // Get the master slide from the first slide of the source presentation
            ISlide sourceSlide = srcPres.Slides[0];
            IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

            // Insert the cloned master slide at position 3 in the destination's master collection
            IMasterSlideCollection masterCollection = destPres.Masters;
            int insertIndex = 3;
            if (insertIndex > masterCollection.Count)
            {
                // If the index is beyond the current count, add to the end
                masterCollection.AddClone(sourceMaster);
            }
            else
            {
                masterCollection.InsertClone(insertIndex, sourceMaster);
            }

            // Save the destination presentation
            destPres.Save(outputPath, SaveFormat.Pptx);

            // Dispose presentations
            srcPres.Dispose();
            destPres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}