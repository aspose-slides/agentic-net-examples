using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtHiddenValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Apply a theme change (example: modify a line style color)
            // This demonstrates applying a theme before validation
            presentation.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

            // Expected visibility after theme application
            bool expectedHidden = false; // set the expected value as needed

            // Iterate through shapes to find SmartArt and validate its Hidden property
            ISlide slide = presentation.Slides[0];
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    bool actualHidden = smartArt.Hidden;

                    if (actualHidden == expectedHidden)
                    {
                        Console.WriteLine("SmartArt hidden property matches expected value: " + actualHidden);
                    }
                    else
                    {
                        Console.WriteLine("SmartArt hidden property does NOT match expected value. Expected: " + expectedHidden + ", Actual: " + actualHidden);
                    }
                }
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}