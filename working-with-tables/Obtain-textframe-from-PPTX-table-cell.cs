using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is a table
            Aspose.Slides.Table table = (Aspose.Slides.Table)slide.Shapes[0];

            // Retrieve the cell at row 0, column 0
            Aspose.Slides.ICell cell = table[0, 0];

            // Get the ITextFrame associated with the cell
            Aspose.Slides.ITextFrame textFrame = cell.TextFrame;

            // Output the current text of the cell
            Console.WriteLine("Cell text: " + textFrame.Text);

            // Modify the text (optional)
            textFrame.Text = "Updated text";

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}