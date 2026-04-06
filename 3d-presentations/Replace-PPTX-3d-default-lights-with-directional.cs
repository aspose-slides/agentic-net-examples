using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Replace3DLights
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            if (args.Length > 0)
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    int slideCount = pres.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        IShape[] shapes = pres.Slides[i].Shapes.ToArray();
                        foreach (IShape shape in shapes)
                        {
                            // Check if shape has 3D format
                            if (shape.ThreeDFormat != null)
                            {
                                // Set a single directional light source
                                shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
                                shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
                            }
                        }
                    }

                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}