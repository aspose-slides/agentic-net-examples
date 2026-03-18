using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.ITable table = (Aspose.Slides.ITable)slide.Shapes[0];
            int rowIndex = 1; // zero‑based row index
            int columnIndex = 2; // zero‑based column index
            Aspose.Slides.ICell cell = table[columnIndex, rowIndex];
            Console.WriteLine("Cell text: " + cell.TextFrame.Text);
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}