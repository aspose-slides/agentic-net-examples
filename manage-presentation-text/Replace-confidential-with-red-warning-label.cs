// -----------------------------------------------------------------------------
// Example: Replace confidential with red warning label using C#
//
// Description:
// Demonstrates how to replace the word "confidential" with a red warning label
// using C# and Aspose.Slides for .NET. The example loads a PPTX file, searches
// for the specified text, applies a red solid fill and larger font size, and
// saves the modified presentation. This pattern can be used to automate
// confidentiality warnings in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Text, Confidential, Warning, Label, Red Fill, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically replace confidential markings with a visible red warning label.
// - Build C# utilities for batch processing of PowerPoint presentations.
// - Integrate text replacement and styling into .NET applications.
// - Ensure compliance by highlighting sensitive content before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ReplaceConfidential
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.PortionFormat format = new Aspose.Slides.PortionFormat
                    {
                        FontHeight = 14f,
                        FillFormat =
                        {
                            FillType = Aspose.Slides.FillType.Solid,
                            SolidFillColor =
                            {
                                Color = Color.Red
                            }
                        }
                    };

                    Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "confidential", "WARNING", format);

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxEditException editEx)
            {
                Console.WriteLine("Presentation edit error: " + editEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
