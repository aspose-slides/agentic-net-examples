// -----------------------------------------------------------------------------
// Example: Replace placeholders on a specific slide in a PPTX using C#
// 
// Description:
// Demonstrates loading a PowerPoint file, creating a sample if missing, accessing
// a slide by zero‑based index, iterating its shapes, replacing placeholder text,
// and saving the updated presentation. Utilizes Aspose.Slides for .NET in a
// console application.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide Index, Placeholder, Text Replacement
// 
// Use Cases:
// - Automate updating template placeholders in generated presentations.
// - Build command‑line tools for batch processing of PPTX files.
// - Integrate slide‑level content customization into .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure source file exists; create a simple sample if it does not.
            if (!File.Exists(sourcePath))
            {
                try
                {
                    using (Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation())
                    {
                        Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                        Aspose.Slides.IShape sampleShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                        ((Aspose.Slides.IAutoShape)sampleShape).TextFrame.Text = "Hello {{Name}}";
                        samplePres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                    Environment.ExitCode = 1;
                    return;
                }
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
                {
                    int slideIndex = 0;

                    if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                    {
                        Console.WriteLine("Slide index " + slideIndex + " is out of range.");
                        Environment.ExitCode = 1;
                        return;
                    }

                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.TextFrame != null && autoShape.TextFrame.Text != null && autoShape.TextFrame.Text.Contains("{{Name}}"))
                            {
                                autoShape.TextFrame.Text = autoShape.TextFrame.Text.Replace("{{Name}}", "John Doe");
                            }
                        }
                    }

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
                Environment.ExitCode = 1;
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
                Environment.ExitCode = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.ExitCode = 1;
            }
        }
    }
}
