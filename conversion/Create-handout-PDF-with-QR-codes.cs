using System;
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HandoutWithQr
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "handout.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation inside try-catch to handle unsupported formats
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Base URL for online slide version (adjust as needed)
            string baseSlideUrl = "https://example.com/presentation/slide/";

            // Iterate through slides and embed QR code images
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                int slideNumber = i + 1;
                string slideUrl = baseSlideUrl + slideNumber;

                // Build QR code image URL using a public QR code service
                string qrServiceUrl = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" + Uri.EscapeDataString(slideUrl);

                // Download QR code image
                byte[] qrImageData = null;
                WebClient webClient = new WebClient();
                try
                {
                    qrImageData = webClient.DownloadData(qrServiceUrl);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to download QR code for slide " + slideNumber + ": " + ex.Message);
                    webClient.Dispose();
                    continue;
                }
                webClient.Dispose();

                // Add QR code picture to the slide (positioned at bottom‑right)
                try
                {
                    IPictureFrame pictureFrame = (IPictureFrame)presentation.Slides[i].Shapes.AddPictureFrame(
                        ShapeType.Rectangle,
                        500,   // X position (adjust as needed)
                        350,   // Y position (adjust as needed)
                        150,   // Width
                        150,   // Height
                        presentation.Images.AddImage(qrImageData));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to add QR code to slide " + slideNumber + ": " + ex.Message);
                }
            }

            // Prepare PDF handout options (4 slides per horizontal page)
            PdfOptions pdfOptions = new PdfOptions
            {
                SlidesLayoutOptions = new HandoutLayoutingOptions
                {
                    Handout = HandoutType.Handouts4Horizontal
                }
            };

            // Save as handout PDF
            try
            {
                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save handout PDF: " + ex.Message);
            }

            // Ensure presentation is saved before exit
            presentation.Dispose();
        }
    }
}