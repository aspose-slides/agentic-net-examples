// -----------------------------------------------------------------------------




// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add PPTX 3d cube set size using C#



//



// Description:



// Demonstrates how to add a 3‑D cube of a specific size to a PPTX file using



// C# and Aspose.Slides for .NET. The example creates a new presentation,



// inserts a rectangular shape, configures its 3‑D format to form a cube with



// width, height and depth of 2 cm, applies a fill color, and saves the result.



//



// Keywords:



// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D, Cube, Size, Presentation Processing, Office Automation



//



// Use Cases:



// - Automate insertion of sized 3‑D cubes into PowerPoint presentations.



// - Build C# utilities for precise 3‑D shape creation in PPTX files.



// - Generate or modify PPTX content programmatically in .NET applications.



// - Validate 3‑D formatting and dimensions before publishing.



// -----------------------------------------------------------------------------



using System;



using Aspose.Slides;



using Aspose.Slides.Export;







namespace AsposeSlidesDemo



{



    class Program



    {



        static void Main(string[] args)



        {



            // Create a new presentation



            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();







            // Get the first slide (or any specific slide by index)



            Aspose.Slides.ISlide slide = presentation.Slides[0];







            // Define size of 2 centimeters in points (1 cm ≈ 28.3464567 points)



            float sizeInPoints = 2f * 28.3464567f;







            // Add a rectangle shape that will be transformed into a 3D cube



            Aspose.Slides.IAutoShape cubeShape = slide.Shapes.AddAutoShape(



                Aspose.Slides.ShapeType.Rectangle,



                100f, // X position



                100f, // Y position



                sizeInPoints, // Width



                sizeInPoints  // Height



            );







            // Set 3D properties to make it appear as a cube



            cubeShape.ThreeDFormat.Depth = sizeInPoints;               // Depth equal to width/height



            cubeShape.ThreeDFormat.ExtrusionHeight = sizeInPoints;    // Extrusion height equal to size



            cubeShape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;







            // Optional: set a simple fill color for better visibility



            cubeShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;



            cubeShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;







            // Save the presentation



            string outputPath = "CubePresentation.pptx";



            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



        }



    }



}



