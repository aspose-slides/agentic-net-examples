using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get the first slide
                Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

                // Add a SmartArt diagram to the source slide
                Aspose.Slides.SmartArt.ISmartArt originalSmartArt = sourceSlide.Shapes.AddSmartArt(
                    50f, 50f, 400f, 300f,
                    Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Store original node count for comparison
                int originalNodeCount = originalSmartArt.AllNodes.Count;

                // Create a blank layout slide for the destination slide
                Aspose.Slides.ILayoutSlide blankLayout = presentation.Masters[0].LayoutSlides.GetByType(
                    Aspose.Slides.SlideLayoutType.Blank);

                // Add a new empty slide using the blank layout
                Aspose.Slides.ISlide destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

                // Clone the original SmartArt shape onto the destination slide
                Aspose.Slides.IShape clonedShape = destinationSlide.Shapes.AddClone(originalSmartArt, 0f, 0f);
                Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = clonedShape as Aspose.Slides.SmartArt.ISmartArt;

                if (clonedSmartArt != null)
                {
                    // Change the layout of the cloned SmartArt to a radial layout
                    clonedSmartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicRadial;

                    // Store cloned node count after layout change
                    int clonedNodeCount = clonedSmartArt.AllNodes.Count;

                    // Output node distribution comparison
                    Console.WriteLine("Original SmartArt node count: " + originalNodeCount);
                    Console.WriteLine("Cloned SmartArt node count after layout change: " + clonedNodeCount);
                }
                else
                {
                    Console.WriteLine("Cloned shape is not a SmartArt diagram.");
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Aspose.Slides.PptxEditException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}