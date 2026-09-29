// -----------------------------------------------------------------------------
// Example: Apply Random Solid Fill Colors to SmartArt Nodes and Export Slide as PNG
//
// Description:
// This console application creates a PowerPoint presentation using Aspose.Slides for .NET,
// adds a SmartArt diagram, assigns random solid fill colors to each SmartArt node shape,
// saves the presentation as a PPTX file, and exports the first slide as a PNG image.
// It demonstrates automated PPTX manipulation, random color styling, and slide image export.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, random fill, PNG export
//
// Use Cases:
// - Generate branded presentations with varied SmartArt colors automatically.
// - Create visual assets from slides for web or documentation.
// - Integrate PowerPoint styling into .NET backend services.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesRandomSmartArtFill
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string outputPptxPath = "SmartArtRandomFill.pptx";
            string outputPngPath = "SmartArtRandomFill.png";

            // Ensure output directory exists
            string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPptxPath));
            if (!String.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    10, 10, 800, 400,
                    Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Prepare random color generator
                Random random = new Random();

                // Apply random solid fill colors to each shape in every SmartArt node
                foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                {
                    foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                    {
                        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        int red = random.Next(256);
                        int green = random.Next(256);
                        int blue = random.Next(256);
                        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(red, green, blue);
                    }
                }

                // Save the presentation as PPTX
                presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Export the first slide as a PNG image
                using (Aspose.Slides.IImage slideImage = slide.GetImage())
                {
                    slideImage.Save(outputPngPath, Aspose.Slides.ImageFormat.Png);
                }

                Console.WriteLine("Presentation saved to: " + Path.GetFullPath(outputPptxPath));
                Console.WriteLine("Slide image saved to: " + Path.GetFullPath(outputPngPath));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
