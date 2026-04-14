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

            Presentation presentation = null;
            try
            {
                if (File.Exists(inputPath))
                {
                    presentation = new Presentation(inputPath);
                }
                else
                {
                    presentation = new Presentation();
                }

                // Iterate through all master slides
                for (int i = 0; i < presentation.Masters.Count; i++)
                {
                    IMasterSlide masterSlide = presentation.Masters[i];
                    // Iterate through all shapes on the master slide
                    for (int j = 0; j < masterSlide.Shapes.Count; j++)
                    {
                        IShape shape = masterSlide.Shapes[j];
                        if (shape is IAutoShape)
                        {
                            IAutoShape autoShape = (IAutoShape)shape;
                            if (autoShape.ShapeType == ShapeType.Line)
                            {
                                // Set dash style to DashDot
                                autoShape.LineFormat.DashStyle = LineDashStyle.DashDot;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("PPTX format not supported: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("PPT format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}