using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

                // Prepare random color selection
                Random random = new Random();
                SchemeColor[] schemeColors = (SchemeColor[])Enum.GetValues(typeof(SchemeColor));

                // Assign a random fill color to each shape in every SmartArt node
                foreach (ISmartArtNode node in smartArt.AllNodes)
                {
                    foreach (ISmartArtShape shape in node.Shapes)
                    {
                        shape.FillFormat.FillType = FillType.Solid;
                        SchemeColor randomColor = schemeColors[random.Next(schemeColors.Length)];
                        shape.FillFormat.SolidFillColor.SchemeColor = randomColor;
                    }
                }

                // Export the slide as a PNG image
                IImage slideImage = slide.GetImage(1f, 1f);
                slideImage.Save("SmartArtSlide.png", Aspose.Slides.ImageFormat.Png);

                // Save the presentation
                presentation.Save("SmartArtPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs)
        }
    }
}