using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSeeAlsoSection
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

            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Add a new empty slide using the first layout slide as a template
            Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Add a rectangle shape that will contain the "See also" text
            Aspose.Slides.IShape shape = newSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50,   // X position
                50,   // Y position
                400,  // Width
                100   // Height
            );

            // Cast the shape to IAutoShape to work with text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
            autoShape.AddTextFrame("See also");

            // Create a new section named "See also" that starts with the newly added slide
            Aspose.Slides.ISection seeAlsoSection = presentation.Sections.AddSection("See also", newSlide);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}