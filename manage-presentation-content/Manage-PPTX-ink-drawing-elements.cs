using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManageInkElements
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to input and output files
                string inputPath = "input.pptx";
                string hiddenPdfPath = "output_hidden.pdf";
                string visiblePdfPath = "output_visible.pdf";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through shapes on the first slide to find Ink objects
                    Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;
                    for (int index = 0; index < shapes.Count; index++)
                    {
                        Aspose.Slides.IShape shape = shapes[index];
                        if (shape is Aspose.Slides.Ink.Ink)
                        {
                            Aspose.Slides.Ink.Ink inkShape = (Aspose.Slides.Ink.Ink)shape;

                            // Modify Ink shape properties
                            inkShape.Width = 400f;   // Set new width
                            inkShape.Height = 200f;  // Set new height
                            inkShape.Hidden = false; // Ensure the shape is visible in the presentation
                        }
                    }

                    // Export PDF with Ink elements hidden
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    pdfOptions.InkOptions.HideInk = true;
                    presentation.Save(hiddenPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                    // Export PDF with Ink elements visible and custom rendering options
                    pdfOptions.InkOptions.HideInk = false;
                    pdfOptions.InkOptions.InterpretMaskOpAsOpacity = false;
                    presentation.Save(visiblePdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}