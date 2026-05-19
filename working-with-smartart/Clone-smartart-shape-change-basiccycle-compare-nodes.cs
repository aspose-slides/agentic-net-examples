using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CloneSmartArt_Output.pptx";

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt shape with an initial layout
                ISmartArt originalSmartArt = slide.Shapes.AddSmartArt(50f, 50f, 400f, 300f, SmartArtLayoutType.BasicBlockList);

                // Store original node count for comparison
                int originalNodeCount = originalSmartArt.Nodes.Count;

                // Clone the SmartArt shape using AddClone (no Clone method on IShape)
                IShape clonedShape = slide.Shapes.AddClone(originalSmartArt, 500f, 50f);

                // Cast the cloned shape back to ISmartArt
                ISmartArt clonedSmartArt = clonedShape as ISmartArt;
                if (clonedSmartArt != null)
                {
                    // Change the layout of the cloned SmartArt to BasicCycle
                    clonedSmartArt.Layout = SmartArtLayoutType.BasicCycle;

                    // Store cloned node count for comparison
                    int clonedNodeCount = clonedSmartArt.Nodes.Count;

                    // Compare node arrangement (here we compare node counts)
                    Console.WriteLine("Original SmartArt node count: " + originalNodeCount);
                    Console.WriteLine("Cloned SmartArt node count after layout change: " + clonedNodeCount);
                }
                else
                {
                    Console.WriteLine("Cloned shape is not a SmartArt diagram.");
                }

                try
                {
                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle exceptions such as unsupported format
                    Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
                }
            }

            // Verify that the file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            else
            {
                Console.WriteLine("Failed to save the presentation.");
            }
        }
    }
}