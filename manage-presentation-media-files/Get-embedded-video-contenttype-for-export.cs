using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output files
            string inputPath = "input.pptx";
            string outputPptxPath = "output.pptx";
            string outputPdfPath = "output.pdf";

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Retrieve and display the content type of each embedded video
                for (int index = 0; index < presentation.Videos.Count; index++)
                {
                    IVideo video = presentation.Videos[index];
                    string contentType = video.ContentType;
                    Console.WriteLine($"Video {index} content type: {contentType}");
                }

                // Export to PPTX format
                presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Export to PDF format using default PDF options
                PdfOptions pdfOptions = new PdfOptions();
                presentation.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}