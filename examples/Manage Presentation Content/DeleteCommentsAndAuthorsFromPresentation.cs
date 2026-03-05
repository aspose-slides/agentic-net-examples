using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing PPT presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.ppt");
        // Remove all comment authors (this also removes their comments)
        presentation.CommentAuthors.Clear();
        // Save the modified presentation in PPT format
        presentation.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        // Release resources
        presentation.Dispose();
    }
}