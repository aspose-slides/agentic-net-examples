using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0f, 0f, 400f, 400f,
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Add a new node to the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.Nodes.AddNode();

            // Get the first shape of the newly added node
            Aspose.Slides.SmartArt.ISmartArtShape nodeShape = newNode.Shapes[0];

            // Set the fill type to Pattern
            nodeShape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;

            // Configure the pattern fill
            nodeShape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DarkHorizontal;
            nodeShape.FillFormat.PatternFormat.ForeColor.Color = Color.Red;
            nodeShape.FillFormat.PatternFormat.BackColor.Color = Color.Yellow;

            // Save the presentation
            try
            {
                presentation.Save("SmartArtPattern.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions (e.g., I/O errors)
            }
        }
    }
}