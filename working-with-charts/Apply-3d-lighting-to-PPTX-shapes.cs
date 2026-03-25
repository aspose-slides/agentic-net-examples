using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        Aspose.Slides.Presentation pres = null;
        try
        {
            if (args.Length > 0)
            {
                string inputPath = args[0];
                if (!File.Exists(inputPath))
                {
                    throw new FileNotFoundException("Input file not found.", inputPath);
                }
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                pres = new Aspose.Slides.Presentation();
            }

            Aspose.Slides.IShape rectShape = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
            rectShape.ThreeDFormat.Depth = 5;
            rectShape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            rectShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            rectShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            rectShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
            rectShape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Flat;

            string outputPath = "output_3d.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}