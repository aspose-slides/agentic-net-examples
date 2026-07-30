// -----------------------------------------------------------------------------
// Example: Replace picture frame image with QR code using C#
//
// Description:
// Demonstrates how to locate the first picture frame on the first slide of a
// PowerPoint presentation and replace its image with a QR code image using
// Aspose.Slides for .NET. The example loads an existing PPTX, reads a QR code
// PNG file, substitutes the picture frame's image, and saves the result as a
// new PPTX file. This pattern can be used in console applications or services
// that need to programmatically update presentation media.
//
// Keywords:
// C#, .NET, PowerPoint, PPTX, Aspose.Slides, QR code, Image replacement, 
// Picture frame, Presentation processing, Office automation
//
// Use Cases:
// - Automatically replace placeholder images with generated QR codes.
// - Build C# utilities for batch updating PPTX files.
// - Integrate QR code insertion into reporting or marketing workflows.
// - Validate and test presentation modifications before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplacePictureFrameWithQr
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationPath = "input.pptx";
            string qrImagePath = "qr.png";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"Presentation file not found: {presentationPath}");
                return;
            }

            if (!File.Exists(qrImagePath))
            {
                Console.WriteLine($"QR code image file not found: {qrImagePath}");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Assume the first picture frame on the first slide is the target
                    ISlide slide = presentation.Slides[0];
                    IPictureFrame pictureFrame = null;

                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IPictureFrame)
                        {
                            pictureFrame = (IPictureFrame)shape;
                            break;
                        }
                    }

                    if (pictureFrame == null)
                    {
                        Console.WriteLine("No picture frame found on the first slide.");
                        return;
                    }

                    // Load QR code image bytes
                    byte[] qrBytes = File.ReadAllBytes(qrImagePath);
                    // Add QR image to presentation's image collection
                    IPPImage qrImage = presentation.Images.AddImage(qrBytes);
                    // Replace the picture frame's image
                    pictureFrame.PictureFormat.Picture.Image = qrImage;

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
