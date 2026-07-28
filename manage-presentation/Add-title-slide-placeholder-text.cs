// -----------------------------------------------------------------------------
// Example: Add title slide placeholder text using C#
//
// Description:
// Demonstrates how to add title slide placeholder text using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Title, Slide, Placeholder, 
// Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add title slide placeholder text.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a title slide based on the first layout slide
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Define the main heading text
        string titleText = "Main Heading";

        // Set placeholder text for the centered title placeholder
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
            {
                string text = null;
                if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle)
                {
                    text = titleText;
                }
                if (text != null)
                {
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = text;
                }
            }
        }

        // Save the presentation
        string outputPath = "TitleSlide.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}
