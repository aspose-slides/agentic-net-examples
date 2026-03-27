using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace InkManagementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string pdfPath = "output.pdf";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
                // Add a simple line shape to the first slide (placeholder for ink)
                ISlide firstSlide = presentation.Slides[0];
                firstSlide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
            }

            // Attempt to work with an Ink object on the first slide
            ISlide slideToEdit = presentation.Slides[0];
            if (slideToEdit.Shapes.Count > 0)
            {
                IShape shape = slideToEdit.Shapes[0];
                Ink inkShape = shape as Ink;
                if (inkShape != null)
                {
                    // Example modification: increase the width of the ink shape
                    inkShape.Width = inkShape.Width + 20;
                    // Example modification: change the position
                    inkShape.X = inkShape.X + 10;
                    inkShape.Y = inkShape.Y + 10;
                }
            }

            // Export the presentation to PDF while hiding ink elements
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.InkOptions.HideInk = true;
            presentation.Save(pdfPath, SaveFormat.Pdf, pdfOptions);

            // Save the (potentially modified) presentation back to PPTX
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}