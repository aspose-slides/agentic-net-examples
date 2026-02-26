using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            System.String inputPath = "input.pptx";
            System.String outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first shape on the first slide (assumed to contain text)
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes[0];

            // Access the effect format of the first portion of the first paragraph
            Aspose.Slides.IEffectFormat effectFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

            // Get the outer shadow effect
            Aspose.Slides.Effects.IOuterShadow outerShadow = effectFormat.OuterShadowEffect;

            // Retrieve the current shadow color
            System.Drawing.Color shadowColor = outerShadow.ShadowColor.Color;

            // Set the shadow color with desired transparency (alpha = 128 for 50% transparency)
            outerShadow.ShadowColor.Color = System.Drawing.Color.FromArgb(128, shadowColor);

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}