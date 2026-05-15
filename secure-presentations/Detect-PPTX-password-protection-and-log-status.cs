using System;
using System.IO;

class Program
{
    static void Main()
    {
        var inputFileName = "sample.pptx";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist: " + filePath);
            return;
        }

        try
        {
            Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(filePath);
            var isPasswordProtected = presentationInfo.IsPasswordProtected;
            if (isPasswordProtected)
                Console.WriteLine("The presentation '" + filePath + "' is protected by password to open.");
            else
                Console.WriteLine("The presentation '" + filePath + "' is not password protected.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}