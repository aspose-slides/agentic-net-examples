using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddWatermarkToPdfNotes
{
    class Program
    {
        static void Main()
        {
            // Input presentation, watermark image and output PDF paths
            string inputPath = "input.pptx";
            string watermarkPath = "watermark.png";
            string outputPath = "output.pdf";

            // Verify that input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            if (!File.Exists(watermarkPath))
            {
                Console.WriteLine("Watermark image file not found: " + watermarkPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Load the watermark image into the presentation's image collection
                    IImage watermarkImage = Images.FromFile(watermarkPath);
                    IPPImage watermarkIPPImage = presentation.Images.AddImage(watermarkImage);

                    // Iterate through all slides and add the watermark to each notes slide
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Ensure a notes slide exists
                        INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
                        if (notesSlide == null)
                        {
                            notesSlide = slide.NotesSlideManager.AddNotesSlide();
                        }

                        // Add the watermark picture to the notes slide
                        // Position and size are set arbitrarily; adjust as needed
                        notesSlide.Shapes.AddPictureFrame(
                            ShapeType.Rectangle,
                            0f,          // X position
                            0f,          // Y position
                            100f,        // Width
                            100f,        // Height
                            watermarkIPPImage);
                    }

                    // Configure PDF export options to include notes pages
                    PdfOptions pdfOptions = new PdfOptions();
                    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                    notesOptions.NotesPosition = NotesPositions.BottomFull;
                    pdfOptions.SlidesLayoutOptions = notesOptions;

                    // Save the presentation as PDF with notes (including watermark)
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The selected file format is not supported for saving.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}