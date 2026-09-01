// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Render slides to high‑resolution PNG images and combine into PDF using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, export each slide as a

// high‑resolution PNG image, then create a new presentation that inserts those

// images onto separate slides and saves the result as a PDF file using

// Aspose.Slides for .NET. The example includes file existence checks, directory

// handling, and error handling for unsupported save formats.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, PNG, PDF, high‑resolution,

// slide rendering, image export, presentation conversion, automation

//

// Use Cases:

// - Convert PPTX slides to high‑resolution PNG images for publishing or review.

// - Generate a PDF document from a presentation by embedding rendered slide images.

// - Automate slide‑to‑image and image‑to‑PDF workflows in .NET applications.

// - Validate and process PowerPoint files before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideToPdfConverter

{

    class Program

    {

        static void Main()

        {

            // Input and output paths

            string inputPath = "input.pptx";

            string outputPdfPath = "output.pdf";

            string imageDir = "SlideImages";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            // Ensure image directory exists

            if (!Directory.Exists(imageDir))

            {

                Directory.CreateDirectory(imageDir);

            }



            // Load the source presentation

            Presentation sourcePresentation = new Presentation(inputPath);



            // High‑resolution scale factor

            float scaleX = 3f;

            float scaleY = 3f;



            // Export each slide as PNG

            for (int i = 0; i < sourcePresentation.Slides.Count; i++)

            {

                ISlide slide = sourcePresentation.Slides[i];

                using (IImage image = slide.GetImage(scaleX, scaleY))

                {

                    string imagePath = Path.Combine(imageDir, $"slide_{i + 1}.png");

                    image.Save(imagePath, Aspose.Slides.ImageFormat.Png);

                }

            }



            // Create a new presentation to hold PNG images

            Presentation pdfPresentation = new Presentation();



            // Add each PNG as a picture on a separate slide

            for (int i = 0; i < sourcePresentation.Slides.Count; i++)

            {

                string imagePath = Path.Combine(imageDir, $"slide_{i + 1}.png");

                if (!File.Exists(imagePath))

                {

                    continue;

                }



                // Add a new slide for all but the first image

                ISlide targetSlide = i == 0 ? pdfPresentation.Slides[0] : pdfPresentation.Slides.AddEmptySlide(pdfPresentation.Slides[0].LayoutSlide);



                // Load image into presentation

                IPPImage pptImage = pdfPresentation.Images.AddImage(Images.FromFile(imagePath));



                // Add picture frame covering the whole slide

                targetSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pdfPresentation.SlideSize.Size.Width, pdfPresentation.SlideSize.Size.Height, pptImage);

            }



            // Save the combined presentation as PDF

            try

            {

                pdfPresentation.Save(outputPdfPath, SaveFormat.Pdf);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported for saving.");

            }



            // Clean up

            sourcePresentation.Dispose();

            pdfPresentation.Dispose();

        }

    }

}

