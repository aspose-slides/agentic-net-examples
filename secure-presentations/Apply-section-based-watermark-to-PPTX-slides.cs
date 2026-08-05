// -----------------------------------------------------------------------------
// Example: Apply section based watermark to PPTX slides using C#
//
// Description:
// Demonstrates how to apply a text watermark to each slide of a PowerPoint
// presentation based on its section name using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, iterates through its sections, decides
// whether to use "CONFIDENTIAL" or "DRAFT" as the watermark text, adds the
// watermark shape to each slide in the section, and saves the modified file.
// This pattern can be used to automate section‑aware watermarking in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Section, Watermark, Presentation
// Processing, Office Automation, Confidential, Draft
//
// Use Cases:
// - Automatically add section‑specific watermarks (e.g., CONFIDENTIAL or DRAFT)
//   to PowerPoint presentations.
// - Build .NET tools that enforce branding or confidentiality policies per
//   presentation section.
// - Integrate watermarking into document generation or publishing pipelines.
// - Validate and transform PPTX files before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplySectionBasedWatermark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Iterate through each section
                for (int secIndex = 0; secIndex < pres.Sections.Count; secIndex++)
                {
                    Aspose.Slides.ISection section = pres.Sections[secIndex];
                    string sectionName = section.Name;

                    // Determine watermark text based on section title
                    string watermarkText = sectionName.IndexOf("Confidential", StringComparison.OrdinalIgnoreCase) >= 0
                        ? "CONFIDENTIAL"
                        : "DRAFT";

                    // Get slides belonging to the current section
                    Aspose.Slides.ISectionSlideCollection slidesInSection = section.GetSlidesListOfSection();

                    // Apply watermark to each slide in the section
                    foreach (Aspose.Slides.ISlide slide in slidesInSection)
                    {
                        Aspose.Slides.IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
                            Aspose.Slides.ShapeType.Rectangle,
                            100,   // X position
                            100,   // Y position
                            400,   // Width
                            50);   // Height

                        watermarkShape.AddTextFrame(watermarkText);
                        watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                        watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                        watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
