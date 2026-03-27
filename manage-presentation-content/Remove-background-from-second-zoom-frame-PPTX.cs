using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveZoomFrameBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            string logoFileName = "logo.png";
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), logoFileName);

            // Load existing presentation if it exists, otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputFile))
            {
                presentation = new Presentation(inputFile);
            }
            else
            {
                presentation = new Presentation();
            }

            using (presentation)
            {
                // Add two empty slides based on the layout of the first slide
                ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Set background for slide2
                slide2.Background.Type = BackgroundType.OwnBackground;
                slide2.Background.FillFormat.FillType = FillType.Solid;
                slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

                // Set background for slide3
                slide3.Background.Type = BackgroundType.OwnBackground;
                slide3.Background.FillFormat.FillType = FillType.Solid;
                slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

                // Add first zoom frame (without image)
                IZoomFrame zoomFrame1 = presentation.Slides[0].Shapes.AddZoomFrame(150f, 20f, 50f, 50f, slide2);
                zoomFrame1.ShowBackground = true; // default, can be omitted

                // Ensure the image file exists before adding it
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine("Image file not found: " + imagePath);
                    return;
                }

                // Add image to the presentation
                IPPImage image = presentation.Images.AddImage(Images.FromFile(imagePath));

                // Add second zoom frame with the image
                IZoomFrame zoomFrame2 = presentation.Slides[0].Shapes.AddZoomFrame(250f, 20f, 50f, 50f, slide3, image);
                // Remove background from the second zoom frame's image
                zoomFrame2.ShowBackground = false;

                // Optional styling for the second zoom frame
                zoomFrame2.LineFormat.Width = 2f;
                zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
                zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
                zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

                // Save the presentation
                presentation.Save(outputFile, SaveFormat.Pptx);
            }
        }
    }
}