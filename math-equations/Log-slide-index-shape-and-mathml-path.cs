// -----------------------------------------------------------------------------
// Example: Export Math Paragraphs to MathML from PowerPoint Slides
//
// Description:
// This console application loads a PowerPoint PPTX file using Aspose.Slides for .NET,
// iterates through each slide and shape, identifies mathematical shapes, and
// exports their MathML representation to separate .mml files. It logs the slide
// index, shape name, and output file path for each successful export.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, mathematical shape, export
//
// Use Cases:
// - Convert embedded equations in presentations to MathML for web publishing.
// - Batch process multiple slides to extract mathematical content.
// - Integrate with documentation pipelines that require MathML output.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathMlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputDirectory = args.Length > 1 ? args[1] : "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"Error: Input file '{inputPath}' does not exist.");
                return;
            }

            string extension = Path.GetExtension(inputPath);
            if (!string.Equals(extension, ".pptx", StringComparison.OrdinalIgnoreCase))
            {
                Console.Error.WriteLine("Error: Unsupported file format. Only PPTX files are supported.");
                return;
            }

            try
            {
                Directory.CreateDirectory(outputDirectory);

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                        if (autoShape == null || autoShape.TextFrame == null)
                        {
                            continue;
                        }

                        if (autoShape.TextFrame.Paragraphs.Count == 0 ||
                            autoShape.TextFrame.Paragraphs[0].Portions.Count == 0)
                        {
                            continue;
                        }

                        Aspose.Slides.MathText.MathPortion mathPortion = autoShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion;
                        if (mathPortion == null)
                        {
                            continue;
                        }

                        Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                        if (mathParagraph == null)
                        {
                            continue;
                        }

                        string outputFilePath = Path.Combine(outputDirectory,
                            $"slide{slideIndex + 1}_shape{shapeIndex + 1}.mml");

                        using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                        {
                            mathParagraph.WriteAsMathMl(fileStream);
                        }

                        string shapeName = string.IsNullOrEmpty(autoShape.Name) ? $"Shape{shapeIndex + 1}" : autoShape.Name;
                        Console.WriteLine($"Slide {slideIndex + 1}, Shape '{shapeName}' exported to {outputFilePath}");
                    }
                }

                // Save the presentation (optional, here we overwrite the original)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
