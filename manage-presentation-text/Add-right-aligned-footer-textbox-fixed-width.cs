// -----------------------------------------------------------------------------
// Example: Add right aligned footer textbox fixed width using C#
//
// Description:
// Demonstrates how to add right aligned footer textbox fixed width using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Right, Aligned, Footer, 
// Textbox, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add right aligned footer textbox fixed width.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
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

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlideSize slideSize = presentation.SlideSize;
                    float slideWidth = slideSize.Size.Width;
                    float slideHeight = slideSize.Size.Height;

                    float footerWidth = 300f;
                    float footerHeight = 30f;
                    float margin = 20f;

                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        float x = slideWidth - margin - footerWidth;
                        float y = slideHeight - margin - footerHeight;

                        Aspose.Slides.IAutoShape footerShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, x, y, footerWidth, footerHeight);
                        footerShape.AddTextFrame("Footer text");
                        footerShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Right;
                        footerShape.TextFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
