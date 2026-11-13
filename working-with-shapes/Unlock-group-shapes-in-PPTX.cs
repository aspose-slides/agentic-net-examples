// -----------------------------------------------------------------------------
// Example: Unlock Group Shapes in PPTX using Aspose.Slides for .NET
//
// Description:
// This console program loads a PPTX file, removes all lock settings from any
// group shapes it contains, and saves the modified presentation. If the input
// file does not exist, a sample PPTX with a locked group shape is created to
// demonstrate the unlocking process. The result is saved as a new PPTX file.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Unlock Group Shape, Shape Lock
//
// Use Cases:
// - Remove editing locks from group shapes before modifying a presentation.
// - Prepare PPTX files for batch automation where locked shapes cause errors.
// - Integrate shape unlocking into custom PowerPoint manipulation tools.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = createPres.Slides[0];
                Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();
                group.Frame = new Aspose.Slides.ShapeFrame(50f, 50f, 400f, 300f, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.False, 0f);
                group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0f, 0f, 100f, 50f);
                group.GroupShapeLock.UngroupingLocked = true;
                group.GroupShapeLock.GroupingLocked = true;
                group.GroupShapeLock.PositionLocked = true;
                group.GroupShapeLock.SizeLocked = true;
                group.GroupShapeLock.RotationLocked = true;
                group.GroupShapeLock.SelectLocked = true;
                group.GroupShapeLock.AspectRatioLocked = true;
                createPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                createPres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                Environment.Exit(1);
            }
        }

        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            Environment.Exit(1);
        }

        try
        {
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IGroupShape groupShape = shape as Aspose.Slides.IGroupShape;
                    if (groupShape != null)
                    {
                        groupShape.GroupShapeLock.UngroupingLocked = false;
                        groupShape.GroupShapeLock.GroupingLocked = false;
                        groupShape.GroupShapeLock.PositionLocked = false;
                        groupShape.GroupShapeLock.SizeLocked = false;
                        groupShape.GroupShapeLock.RotationLocked = false;
                        groupShape.GroupShapeLock.SelectLocked = false;
                        groupShape.GroupShapeLock.AspectRatioLocked = false;
                    }
                }
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
            if (pres != null)
            {
                pres.Dispose();
            }
            Environment.Exit(1);
        }

        pres.Dispose();
    }
}
