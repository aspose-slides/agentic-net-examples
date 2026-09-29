// -----------------------------------------------------------------------------
// Example: Clone SmartArt Shape and Compare Layouts in C# with Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, adds an
// Organization Chart SmartArt shape, clones the SmartArt using the Aspose.Slides
// API, changes the cloned shape's layout to a horizontal process layout, prints
// the layout types of both original and cloned SmartArt objects to the console,
// and saves the resulting presentation as a PPTX file. The example demonstrates
// shape cloning, layout modification, and simple comparison of SmartArt properties.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, clone, layout comparison
//
// Use Cases:
// - Generate duplicate SmartArt diagrams with different visual arrangements.
// - Programmatically adjust SmartArt layouts for dynamic report generation.
// - Compare SmartArt configurations during automated presentation testing.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace AsposeSlidesSmartArtCloneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation.
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide.
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add an Organization Chart SmartArt shape.
                Aspose.Slides.SmartArt.ISmartArt originalSmartArt = slide.Shapes.AddSmartArt(
                    50,               // X position
                    50,               // Y position
                    600,              // Width
                    400,              // Height
                    Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

                // Clone the SmartArt shape using the shape collection's AddClone method.
                Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(originalSmartArt);

                // Cast the cloned shape back to ISmartArt.
                Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = (Aspose.Slides.SmartArt.ISmartArt)clonedShape;

                // Change the layout of the cloned SmartArt to a horizontal process layout.
                clonedSmartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess;

                // Output the layout types of the original and cloned SmartArt objects.
                Console.WriteLine("Original SmartArt layout: " + originalSmartArt.Layout);
                Console.WriteLine("Cloned SmartArt layout: " + clonedSmartArt.Layout);

                // Save the presentation to a PPTX file.
                string outputPath = "CloneSmartArtDemo.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up.
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
