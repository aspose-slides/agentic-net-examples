// -----------------------------------------------------------------------------
// Example: Remove PPTX 3d objects without animations using C#
//
// Description:
// Demonstrates how to remove 3‑D objects that have no animation effects from a
// PowerPoint presentation using Aspose.Slides for .NET. The example loads a
// PPTX file, scans each slide for shapes with a ThreeDFormat, checks the slide
// timeline for associated animation effects, removes the shapes that have no
// animations, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, 3D Objects, Without,
// Animations, Presentation Processing, Office Automation
//
// Use Cases:
// - Clean up PPTX files by deleting unused 3‑D shapes.
// - Prepare presentations for environments that do not support 3‑D objects.
// - Automate preprocessing of PowerPoint files before publishing.
// - Integrate 3‑D object removal into .NET based document workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception)
        {
            // format not supported
            Console.WriteLine("File format not supported or error loading presentation.");
            return;
        }

        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            System.Collections.Generic.List<Aspose.Slides.IShape> shapesToRemove = new System.Collections.Generic.List<Aspose.Slides.IShape>();
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.ThreeDFormat != null)
                {
                    int effectCount = slide.Timeline.MainSequence.GetCount(shape);
                    if (effectCount == 0)
                    {
                        shapesToRemove.Add(shape);
                    }
                }
            }

            foreach (Aspose.Slides.IShape shape in shapesToRemove)
            {
                slide.Shapes.Remove(shape);
            }
        }

        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
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
