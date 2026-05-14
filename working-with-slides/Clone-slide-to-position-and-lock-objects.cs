using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string inputPath = "CloneWithInSamePresentation.pptx";
            string outputPath = "Aspose_CloneWithInSamePresentation_out.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlideCollection slides = pres.Slides;
                    // Clone slide at index 1 to position 2 within the same presentation
                    Aspose.Slides.ISlide clonedSlide = slides.InsertClone(2, slides[1]);

                    // Lock all graphical objects on the cloned slide
                    foreach (Aspose.Slides.IShape shape in clonedSlide.Shapes)
                    {
                        if (shape is Aspose.Slides.IGraphicalObject)
                        {
                            Aspose.Slides.IGraphicalObject gobj = (Aspose.Slides.IGraphicalObject)shape;
                            gobj.ShapeLock.PositionLocked = true;
                            gobj.ShapeLock.SizeLocked = true;
                            gobj.ShapeLock.AspectRatioLocked = true;
                        }
                        else if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape auto = (Aspose.Slides.IAutoShape)shape;
                            auto.AutoShapeLock.PositionLocked = true;
                            auto.AutoShapeLock.SizeLocked = true;
                            auto.AutoShapeLock.AspectRatioLocked = true;
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}