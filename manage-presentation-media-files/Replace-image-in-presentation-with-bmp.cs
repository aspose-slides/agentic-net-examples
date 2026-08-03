// -----------------------------------------------------------------------------
// Example: Replace first image in a PPTX with a BMP using C#
//
// Description:
// Demonstrates how to load a PPTX file, replace the first embedded image with a
// BMP file, and save the updated presentation using Aspose.Slides for .NET.
// The example includes validation of input files and handling of presentations
// that contain no images.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Image, BMP, Presentation
// Processing, Office Automation
//
// Use Cases:
// - Replace a specific image in existing presentations with a BMP asset.
// - Automate batch image updates in PPTX files.
// - Build .NET tools for PPTX image management.
// - Validate image replacement workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string bmpPath = "newImage.bmp";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist.");
                return;
            }

            if (!File.Exists(bmpPath))
            {
                Console.WriteLine("BMP image file does not exist.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    if (pres.Images.Count == 0)
                    {
                        Console.WriteLine("No images in the presentation to replace.");
                    }
                    else
                    {
                        byte[] newImageData = File.ReadAllBytes(bmpPath);
                        Aspose.Slides.IPPImage existingImage = pres.Images[0];
                        existingImage.ReplaceImage(newImageData);
                    }

                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
