using System;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        // Test that setting DefaultRegularFont to null throws an ArgumentNullException
        try
        {
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.DefaultRegularFont = null;
            Console.WriteLine("Test Failed: No exception was thrown when setting DefaultRegularFont to null.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Test Passed: ArgumentNullException was thrown as expected.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Test Failed: Unexpected exception type: " + ex.GetType().FullName);
        }
    }
}