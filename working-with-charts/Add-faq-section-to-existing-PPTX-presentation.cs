using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertFaqSection
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            using (Presentation pres = new Presentation(inputPath))
            {
                // Add a new section for FAQ
                pres.Sections.AddSection("FAQ", pres.Slides[0]);

                // Append an empty section to hold the FAQ slide
                ISection faqSection = pres.Sections.AppendEmptySection("FAQ Section");

                // Clone the first slide into the new FAQ section
                pres.Slides.AddClone(pres.Slides[0], faqSection);

                // Get the newly added FAQ slide (last slide in collection)
                ISlide faqSlide = pres.Slides[pres.Slides.Count - 1];

                // Add a rectangle shape to hold FAQ content
                IAutoShape rectShape = (IAutoShape)faqSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 400);
                rectShape.TextFrame.Text = "FAQ\nQ1: What is Aspose.Slides?\nA1: A .NET library for PowerPoint.\n\nQ2: How to add a slide?\nA2: Use Slides.AddClone or InsertClone methods.";

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}