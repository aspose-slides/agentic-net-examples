using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CloneSmartArtRadial.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram with OrganizationChart layout
                Aspose.Slides.SmartArt.ISmartArt originalSmartArt = slide.Shapes.AddSmartArt(
                    20f, 20f, 600f, 500f,
                    Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

                // Count nodes before cloning
                int originalNodeCount = originalSmartArt.AllNodes.Count;

                // Clone the SmartArt shape using AddClone (position the clone to the right)
                Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(originalSmartArt, 650f, 20f);

                // Cast the cloned shape back to ISmartArt
                Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = clonedShape as Aspose.Slides.SmartArt.ISmartArt;

                if (clonedSmartArt != null)
                {
                    // Change layout of the cloned SmartArt to a radial layout (BasicRadial)
                    clonedSmartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicRadial;

                    // Count nodes after changing layout
                    int clonedNodeCount = clonedSmartArt.AllNodes.Count;

                    // Output node counts to console
                    Console.WriteLine("Original SmartArt node count: " + originalNodeCount);
                    Console.WriteLine("Cloned SmartArt node count after layout change: " + clonedNodeCount);
                }
                else
                {
                    Console.WriteLine("Cloned shape is not a SmartArt diagram.");
                }

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, cloning errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}