// -----------------------------------------------------------------------------
// Example: Set PDF Read‑Only Permission for Viewing Using Aspose.Slides
//
// Description:
// This console application creates a simple PowerPoint presentation, configures
// PDF export options to enforce view‑only permissions, and saves the result as a
// password‑protected PDF. It demonstrates using Aspose.Slides for .NET to set
// PDF access permissions, a common requirement for secure document distribution.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF read‑only, access permissions
//
// Use Cases:
// - Generate corporate slide decks that must be shared as non‑editable PDFs.
// - Automate creation of view‑only PDFs for compliance or archival purposes.
// - Integrate PDF permission settings into CI/CD pipelines for documentation releases.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace AsposeSlidesPdfReadOnlyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPdfPath = "ReadOnlyPresentation.pdf";

            try
            {
                // Create a new presentation instance.
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Add a blank slide based on the default layout.
                    Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                    // Insert a rectangle shape with a text frame.
                    Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        50,
                        50,
                        400,
                        100);
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    autoShape.AddTextFrame("This PDF is view‑only.");

                    // Configure PDF export options to enforce view‑only permissions.
                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    // No permissions are granted; the document can only be viewed.
                    pdfOptions.AccessPermissions = Aspose.Slides.Export.PdfAccessPermissions.None;
                    // Set an owner password to protect the permission settings.
                    pdfOptions.Password = "ownerPassword";

                    // Save the presentation as a PDF with the specified options.
                    presentation.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("PDF saved with view‑only permissions to: " + outputPdfPath);
            }
            catch (System.IO.FileNotFoundException fileNotFoundEx)
            {
                Console.WriteLine("File not found: " + fileNotFoundEx.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
