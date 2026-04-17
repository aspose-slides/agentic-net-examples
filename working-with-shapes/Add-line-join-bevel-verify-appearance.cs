using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line shape to the slide
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

            // Set line width
            line.LineFormat.Width = 5;

            // Set line join style to Bevel
            line.LineFormat.JoinStyle = LineJoinStyle.Bevel;

            // Verify that the join style was set correctly
            if (line.LineFormat.JoinStyle == LineJoinStyle.Bevel)
            {
                Console.WriteLine("Line join style set to Bevel successfully.");
            }
            else
            {
                Console.WriteLine("Failed to set line join style.");
            }

            // Save the presentation
            string outputPath = "LineJoinBevel.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}