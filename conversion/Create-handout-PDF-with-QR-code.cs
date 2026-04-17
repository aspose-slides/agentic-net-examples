using System;
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HandoutQrCodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "handout.pdf";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through slides and add QR code images
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];

                    // Construct online URL for the slide (example)
                    string onlineUrl = "https://example.com/slides/" + (i + 1).ToString();

                    // QR code generation service URL
                    string qrServiceUrl = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" + onlineUrl;

                    byte[] qrImageData = null;

                    // Download QR code image (handle external URL exceptions)
                    try
                    {
                        WebClient client = new WebClient();
                        qrImageData = client.DownloadData(qrServiceUrl);
                        client.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to download QR code for slide " + (i + 1) + ": " + ex.Message);
                        continue; // Skip adding QR code for this slide
                    }

                    if (qrImageData != null && qrImageData.Length > 0)
                    {
                        // Add picture frame with QR code image to the slide
                        // Position the QR code at bottom-right corner (example coordinates)
                        int pictureX = 500;
                        int pictureY = 350;
                        int pictureWidth = 150;
                        int pictureHeight = 150;

                        slide.Shapes.AddPictureFrame(
                            ShapeType.Rectangle,
                            pictureX,
                            pictureY,
                            pictureWidth,
                            pictureHeight,
                            pres.Images.AddImage(qrImageData));
                    }
                }

                // Prepare PDF options for handout layout
                PdfOptions options = new PdfOptions
                {
                    ShowHiddenSlides = true,
                    SlidesLayoutOptions = new HandoutLayoutingOptions
                    {
                        Handout = HandoutType.Handouts4Horizontal
                    }
                };

                // Save as handout PDF
                pres.Save(outputPath, SaveFormat.Pdf, options);

                // Dispose presentation
                pres.Dispose();

                Console.WriteLine("Handout PDF created successfully: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}