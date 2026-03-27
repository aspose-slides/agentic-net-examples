using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableOfContentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output_with_toc.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Insert a new empty slide at the beginning to serve as the Table of Contents
                // Clone the first slide (any slide) and then clear its shapes
                Aspose.Slides.ISlide tocSlide = presentation.Slides.InsertClone(0, presentation.Slides[0]);

                // Remove all existing shapes from the cloned slide
                Aspose.Slides.IShapeCollection tocShapes = tocSlide.Shapes;
                for (int i = tocShapes.Count - 1; i >= 0; i--)
                {
                    tocShapes.RemoveAt(i);
                }

                // Add a title shape for the TOC
                Aspose.Slides.IAutoShape titleShape = (Aspose.Slides.IAutoShape)tocShapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
                titleShape.AddTextFrame("Table of Contents");
                titleShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
                titleShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

                // Create TOC entries linking to each slide (starting from slide 2, because slide 1 is the TOC)
                int entryY = 80;
                for (int i = 1; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide targetSlide = presentation.Slides[i];

                    // Add a rectangle shape for the entry
                    Aspose.Slides.IAutoShape entryShape = (Aspose.Slides.IAutoShape)tocShapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, entryY, 600, 30);
                    string entryText = "Slide " + (i + 1);
                    entryShape.AddTextFrame(entryText);
                    entryShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;

                    // Assign an internal hyperlink to the target slide
                    entryShape.HyperlinkClick = new Aspose.Slides.Hyperlink(targetSlide);

                    entryY += 40; // Move down for the next entry
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved with Table of Contents: " + outputPath);
            }
        }
    }
}