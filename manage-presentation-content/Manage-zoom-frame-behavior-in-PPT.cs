using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Ensure there are at least two slides for the zoom frame target
        if (pres.Slides.Count < 2)
        {
            Aspose.Slides.ISlide extraSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        }

        // Get references to the source and target slides
        Aspose.Slides.ISlide sourceSlide = pres.Slides[0];
        Aspose.Slides.ISlide targetSlide = pres.Slides[1];

        // Add a zoom frame to the source slide linking to the target slide
        Aspose.Slides.IZoomFrame zoomFrame = sourceSlide.Shapes.AddZoomFrame(100f, 100f, 200f, 150f, targetSlide);
        zoomFrame.ReturnToParent = true;          // Return to parent slide after zoom
        zoomFrame.ShowBackground = false;         // Do not show background of target slide

        // Adjust view zoom scales for slide and notes view
        pres.ViewProperties.SlideViewProperties.Scale = 80;   // 80% zoom for slide view
        pres.ViewProperties.NotesViewProperties.Scale = 80;   // 80% zoom for notes view

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}