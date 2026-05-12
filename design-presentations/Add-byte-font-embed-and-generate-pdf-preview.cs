using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddByteFontEmbedAndGeneratePdfPreview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source presentation and the custom font file
            string presentationPath = "input.pptx";
            string fontPath = "customfont.ttf";

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Verify that the font file exists
            if (!File.Exists(fontPath))
            {
                Console.WriteLine("Font file not found: " + fontPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Read the font file into a byte array
                    byte[] fontData = File.ReadAllBytes(fontPath);

                    // Embed the font into the presentation (embed all characters)
                    presentation.FontsManager.AddEmbeddedFont(fontData, EmbedFontCharacters.All);

                    // Save the updated presentation (optional, ensures changes are persisted)
                    string updatedPresentationPath = "output_embedded.pptx";
                    presentation.Save(updatedPresentationPath, SaveFormat.Pptx);

                    // Prepare PDF export options (customize as needed)
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.EmbedFullFonts = true; // embed full fonts in the PDF
                    pdfOptions.ShowHiddenSlides = true; // include hidden slides in the preview

                    // Export the presentation to PDF using the correct overload
                    string pdfOutputPath = "preview.pdf";
                    presentation.Save(pdfOutputPath, SaveFormat.Pdf, pdfOptions);

                    Console.WriteLine("PDF preview generated successfully: " + pdfOutputPath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested file format is not supported by Aspose.Slides.
                Console.WriteLine("The requested file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, licensing issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}