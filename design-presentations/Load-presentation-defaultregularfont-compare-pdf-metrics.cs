using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string pdfPath = "output.pdf";
        string outputPresentationPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Set default regular font using LoadOptions
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultRegularFont = "Arial";

            // Load the presentation with the specified load options
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Configure PDF save options with the same default regular font
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.DefaultRegularFont = "Arial";

                // Save the presentation as PDF
                pres.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                // Placeholder for comparing text metrics between original and PDF
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            string text = autoShape.TextFrame.Text;
                            // In a real scenario, compare text metrics here
                            Console.WriteLine("Slide {0}, Shape {1}: {2}", slide.SlideNumber, shape.Name, text);
                        }
                    }
                }

                // Save the (possibly modified) presentation before exiting
                pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
            // Comment: format not supported
        }
    }
}