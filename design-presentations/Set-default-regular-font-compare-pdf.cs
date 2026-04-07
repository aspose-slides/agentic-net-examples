using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontMetricsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string pdfPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Set default regular font using LoadOptions
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DefaultRegularFont = "Arial";

                // Load presentation with the specified load options
                Presentation pres = new Presentation(inputPath, loadOptions);

                // Calculate simple text metric: total number of characters in the presentation
                int totalCharacters = 0;
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        if (slide.Shapes[j] is IAutoShape)
                        {
                            IAutoShape autoShape = (IAutoShape)slide.Shapes[j];
                            ITextFrame textFrame = autoShape.TextFrame;
                            if (textFrame != null)
                            {
                                for (int p = 0; p < textFrame.Paragraphs.Count; p++)
                                {
                                    IParagraph paragraph = textFrame.Paragraphs[p];
                                    for (int po = 0; po < paragraph.Portions.Count; po++)
                                    {
                                        IPortion portion = paragraph.Portions[po];
                                        if (portion.Text != null)
                                        {
                                            totalCharacters += portion.Text.Length;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Total characters in original presentation: " + totalCharacters);

                // Save presentation as PDF
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.DefaultRegularFont = "Arial";
                pres.Save(pdfPath, SaveFormat.Pdf, pdfOptions);

                // Placeholder for comparing text metrics against PDF.
                // In a real scenario, you would extract text from the PDF and compute metrics.
                Console.WriteLine("PDF generated at: " + pdfPath);
                Console.WriteLine("Text metric comparison not implemented in this example.");

                // Save presentation before exit (as per requirement)
                string savedPptxPath = "saved_output.pptx";
                pres.Save(savedPptxPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}