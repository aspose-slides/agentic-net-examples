using System;
using Aspose.Slides.Export;

namespace MathEquationRenderer
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the PowerPoint presentation containing mathematical equations
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Iterate through each slide and export it as a high‑resolution PNG image
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[index];

                    // Use the GetImage(scaleX, scaleY) overload for high‑resolution output
                    using (Aspose.Slides.IImage image = slide.GetImage(2f, 2f))
                    {
                        string imagePath = $"slide_{index + 1}.png";
                        image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the (potentially modified) presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}