using System;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Iterate through all shapes on the slide
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[j];

                        // Process only picture frames
                        if (shape is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;

                            // Set size (width and height in points)
                            pictureFrame.Width = 400f;
                            pictureFrame.Height = 300f;

                            // Center the picture frame on the slide
                            float centerX = (presentation.SlideSize.Size.Width - pictureFrame.Width) / 2;
                            float centerY = (presentation.SlideSize.Size.Height - pictureFrame.Height) / 2;
                            pictureFrame.X = centerX;
                            pictureFrame.Y = centerY;

                            // Apply a red border with a thickness of 5 points
                            if (pictureFrame.LineFormat != null)
                            {
                                pictureFrame.LineFormat.Width = 5f;
                                pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}