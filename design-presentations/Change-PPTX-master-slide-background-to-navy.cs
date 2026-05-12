using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation pres = null;
            try
            {
                if (File.Exists(inputPath))
                {
                    pres = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    pres = new Aspose.Slides.Presentation();
                }

                // Change the background of the first master slide to solid navy color
                if (pres.Masters.Count > 0)
                {
                    Aspose.Slides.IMasterSlide masterSlide = pres.Masters[0];
                    masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.Navy;
                }

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}