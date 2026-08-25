// -----------------------------------------------------------------------------










// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Rotate PPTX 3d shapes around y axis using C#







//







// Description:







// Demonstrates how to rotate 3D shapes around the Y axis in a PPTX file using







// C# and Aspose.Slides for .NET. The example loads a presentation, applies a







// 45‑degree Y‑axis rotation to each shape's 3D format, and saves the result.







// This pattern can be used to automate PowerPoint 3D transformations in .NET







// applications.







//







// Keywords:







// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rotate, 3D, Shapes, Y-Axis,







// Presentation Processing, Office Automation







//







// Use Cases:







// - Automate rotating PPTX 3D shapes around the Y axis.







// - Build C# tools for PowerPoint 3D presentation processing.







// - Generate or transform PPTX files with custom 3D rotations in .NET.







// - Validate 3D presentation workflows before publishing or integration.







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















        try







        {







            var presentation = new Presentation(inputPath);







            foreach (var slide in presentation.Slides)







            {







                foreach (var shape in slide.Shapes)







                {







                    // Apply 45-degree rotation around Y-axis







                    shape.ThreeDFormat.Camera.SetRotation(0, 45, 0);







                }







            }















            // Ensure output directory exists







            var outDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));







            if (!Directory.Exists(outDir))







            {







                Directory.CreateDirectory(outDir);







            }















            presentation.Save(outputPath, SaveFormat.Pptx);







        }







        catch (Exception ex)







        {







            // Handle unsupported format or other errors







            Console.WriteLine("Error: " + ex.Message);







        }







    }







}







