// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply 3d rotation to picture frames using C#

//

// Description:

// Demonstrates how to apply 3d rotation to picture frames using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Rotation, Picture, 

// Frames, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate apply 3d rotation to picture frames.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation

        Presentation presentation = new Presentation();



        // Add a second slide based on the layout of the first slide

        ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);



        // Path to an example image

        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "example.jpg");



        // Check if the image file exists

        if (!File.Exists(imagePath))

        {

            Console.WriteLine("Image file not found: " + imagePath);

        }

        else

        {

            // Load image and add a picture frame to the second slide

            IImage img = Aspose.Slides.Images.FromFile(imagePath);

            IPPImage picture = presentation.Images.AddImage(img);

            IPictureFrame pictureFrame = secondSlide.Shapes.AddPictureFrame(0, 100, 100, 200, 200, picture);



            // Apply 3‑D rotation effect to the picture frame

            pictureFrame.ThreeDFormat.Depth = 5;

            pictureFrame.ThreeDFormat.Camera.SetRotation(30, 40, 50);

            pictureFrame.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;

            pictureFrame.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

        }



        // Apply the same 3‑D effect to any other picture frames on the second slide

        foreach (IShape shape in secondSlide.Shapes)

        {

            if (shape is IPictureFrame)

            {

                IPictureFrame pf = (IPictureFrame)shape;

                pf.ThreeDFormat.Depth = 5;

                pf.ThreeDFormat.Camera.SetRotation(30, 40, 50);

                pf.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;

                pf.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

            }

        }



        // Save the presentation

        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        try

        {

            presentation.Save(outputPath, SaveFormat.Pptx);

        }

        catch (Exception)

        {

            // Format not supported

        }

    }

}

