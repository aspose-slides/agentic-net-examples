using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation pres = new Presentation(inputPath))
            {
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        OleObjectFrame oleFrame = shape as OleObjectFrame;
                        if (oleFrame != null)
                        {
                            // Lock position and size of the OLE object frame
                            oleFrame.GraphicalObjectLock.PositionLocked = true;
                            oleFrame.GraphicalObjectLock.SizeLocked = true;
                        }
                    }
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}