// -----------------------------------------------------------------------------
// Example: Remove presentation opening password after LDAP authentication using C#
//
// Description:
// Demonstrates how to remove a PowerPoint presentation opening password after
// successful LDAP authentication using C# and Aspose.Slides for .NET. The example
// loads a password‑protected PPTX file, validates the password, and then removes
// the encryption, saving the file without a password. This pattern can be used
// to automate secure presentation workflows in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Opening, Password, LDAP,
// Authentication, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of presentation opening passwords after LDAP user verification.
// - Build C# tools for secure PowerPoint file handling.
// - Integrate presentation de‑protection into .NET services or applications.
// - Prepare PPTX files for distribution after confirming user credentials.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input presentation file
        string pptFileName = "protected.pptx";
        string pptPath = Path.Combine(Directory.GetCurrentDirectory(), pptFileName);
        if (!File.Exists(pptPath))
        {
            Console.WriteLine("Presentation file not found: " + pptPath);
            return;
        }

        // Get presentation information
        IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(pptPath);
        if (!presentationInfo.IsPasswordProtected)
        {
            Console.WriteLine("Presentation is not password protected.");
            return;
        }

        // Obtain password from user (placeholder)
        string userPassword = "userEnteredPassword";

        // Verify user credentials via LDAP service
        bool isLdapAuthenticated = false;
        try
        {
            // Replace with actual LDAP authentication logic
            isLdapAuthenticated = AuthenticateUserViaLdap(userPassword);
        }
        catch (Exception ex)
        {
            Console.WriteLine("LDAP authentication failed: " + ex.Message);
            return;
        }

        if (!isLdapAuthenticated)
        {
            Console.WriteLine("User authentication failed.");
            return;
        }

        // Verify presentation password
        bool isPasswordCorrect = presentationInfo.CheckPassword(userPassword);
        if (!isPasswordCorrect)
        {
            Console.WriteLine("Incorrect presentation password.");
            return;
        }

        // Open the password‑protected presentation
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.Password = userPassword;
        try
        {
            using (Presentation presentation = new Presentation(pptPath, loadOptions))
            {
                // Remove the opening password
                presentation.ProtectionManager.RemoveEncryption();

                // Save the presentation (overwrites original)
                presentation.Save(pptPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
            return;
        }

        Console.WriteLine("Opening password removed successfully.");
    }

    // Placeholder method for LDAP authentication
    static bool AuthenticateUserViaLdap(string password)
    {
        // Simulate successful LDAP authentication
        return true;
    }
}
