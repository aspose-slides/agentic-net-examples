using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add an Organization Chart SmartArt to the first slide
            Aspose.Slides.SmartArt.ISmartArt originalSmartArt = presentation.Slides[0].Shapes.AddSmartArt(
                20f, 20f, 600f, 500f,
                Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Store original node count for comparison
            int originalNodeCount = originalSmartArt.AllNodes.Count;

            // Clone the SmartArt shape using AddClone (no Clone method on ISmartArt)
            Aspose.Slides.IShape clonedShape = presentation.Slides[0].Shapes.AddClone(originalSmartArt, 650f, 20f);

            // Cast the cloned shape back to ISmartArt
            Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = clonedShape as Aspose.Slides.SmartArt.ISmartArt;
            if (clonedSmartArt == null)
            {
                Console.WriteLine("Cloned shape is not a SmartArt object.");
                return;
            }

            // Change the layout of the cloned SmartArt to Horizontal Organization Chart
            clonedSmartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.HorizontalOrganizationChart;

            // Store cloned node count for comparison
            int clonedNodeCount = clonedSmartArt.AllNodes.Count;

            // Compare node arrangements (here we compare node counts)
            bool nodeCountEqual = originalNodeCount == clonedNodeCount;
            Console.WriteLine("Original SmartArt node count: " + originalNodeCount);
            Console.WriteLine("Cloned SmartArt node count: " + clonedNodeCount);
            Console.WriteLine("Node count equal after layout change: " + nodeCountEqual);

            // Save the presentation
            try
            {
                presentation.Save("CloneSmartArtHorizontal.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
            }
        }
    }
}