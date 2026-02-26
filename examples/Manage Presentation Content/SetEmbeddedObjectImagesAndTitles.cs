using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the input and output presentations
        string inputPath = "input.ppt";
        string outputPath = "output.ppt";

        // Load an existing presentation
        Presentation presentation = new Presentation(inputPath);

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Iterate through all shapes on the slide
        for (int i = 0; i < slide.Shapes.Count; i++)
        {
            IShape shape = slide.Shapes[i];

            // Check if the shape is an OLE object frame
            IOleObjectFrame oleObject = shape as IOleObjectFrame;
            if (oleObject != null)
            {
                // Display the OLE object as an icon
                oleObject.IsObjectIcon = true;

                // Set a custom title for the OLE icon
                oleObject.SubstitutePictureTitle = "Custom OLE Icon Title";
            }
        }

        // Save the modified presentation in PPT format
        presentation.Save(outputPath, SaveFormat.Ppt);

        // Clean up resources
        presentation.Dispose();
    }
}