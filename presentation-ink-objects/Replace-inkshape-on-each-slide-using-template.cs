using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace ReplaceInkShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string templatePath = "template.pptx";
            string outputPath = "output.pptx";

            // Verify that input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            if (!File.Exists(templatePath))
            {
                Console.WriteLine($"Template file not found: {templatePath}");
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePres = new Presentation(inputPath))
                {
                    // Load the template presentation containing the Ink shape to copy
                    using (Presentation templatePres = new Presentation(templatePath))
                    {
                        // Find the first Ink shape in the template
                        Ink templateInk = null;
                        foreach (IShape shape in templatePres.Slides[0].Shapes)
                        {
                            if (shape is Ink)
                            {
                                templateInk = shape as Ink;
                                break;
                            }
                        }

                        if (templateInk == null)
                        {
                            Console.WriteLine("No Ink shape found in the template.");
                            return;
                        }

                        // Iterate through each slide in the source presentation
                        foreach (ISlide slide in sourcePres.Slides)
                        {
                            // Collect existing Ink shapes to remove
                            System.Collections.Generic.List<IShape> inksToRemove = new System.Collections.Generic.List<IShape>();
                            foreach (IShape shape in slide.Shapes)
                            {
                                if (shape is Ink)
                                {
                                    inksToRemove.Add(shape);
                                }
                            }

                            // Remove existing Ink shapes
                            foreach (IShape inkShape in inksToRemove)
                            {
                                slide.Shapes.Remove(inkShape);
                            }

                            // Add a cloned Ink shape from the template
                            Ink newInk = slide.Shapes.AddClone(templateInk) as Ink;

                            // Optionally adjust position or size of the new Ink shape
                            if (newInk != null)
                            {
                                newInk.X = 100;
                                newInk.Y = 100;
                                newInk.Width = 300;
                                newInk.Height = 200;
                            }
                        }

                        // Save the modified presentation
                        sourcePres.Save(outputPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors, network errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}