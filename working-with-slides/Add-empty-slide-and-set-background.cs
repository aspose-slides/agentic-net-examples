// -----------------------------------------------------------------------------
// Example: Add Empty Slide and Set Background Image Using Aspose.Slides
//
// Description:
// Demonstrates how to create a new PowerPoint presentation, add an empty slide,
// set its background to an image file, and save the result as a PPTX. The program
// generates a sample background image if it does not exist, making the example
// self‑contained and suitable for automation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Empty Slide, Background Image, Automation
//
// Use Cases:
// - Programmatically generate slides with custom image backgrounds.
// - Build .NET tools for creating branded PowerPoint decks.
// - Automate slide creation with predefined styling.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            string imagePath = "background.jpg";

            // Ensure the background image exists; create a simple placeholder if missing.
            if (!File.Exists(imagePath))
            {
                try
                {
                    using (Bitmap bitmap = new Bitmap(800, 600))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.Clear(Color.LightBlue);
                            using (Font font = new Font("Arial", 48, FontStyle.Bold))
                            {
                                graphics.DrawString("Sample Background", font, Brushes.DarkBlue, new PointF(50, 250));
                            }
                        }
                        bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create placeholder image: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
                    Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(blankLayout);

                    Aspose.Slides.IPPImage backgroundImage = presentation.Images.AddImage(File.ReadAllBytes(imagePath));

                    newSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    newSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                    newSlide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                    newSlide.Background.FillFormat.PictureFillFormat.Picture.Image = backgroundImage;

                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The provided image format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
