#r "SendGrid"
using System;
using SendGrid.Helpers.Mail;
using System.Globalization;
public static void Run(Stream myBlob,string name,IDictionary<string, string> Metadata, ILogger log, out SendGridMessage
message)
{
    var messageText = "";
    var emailTo = "charkivskyi.andrii@gmail.com";

    if (Metadata.ContainsKey("originalFileName") && Metadata.ContainsKey("email")) 
    {
        var indMapper = new IdnMapping();
        var asciiFileName = Metadata["originalFileName"];
        var asciiEmail = Metadata["email"];

        var originalFileName = indMapper.GetUnicode(asciiFileName);
        var originalEmail = indMapper.GetUnicode(asciiEmail);

        messageText = "File has been added to the blob storage: " + originalFileName;
        emailTo = originalEmail;
    }
    else
    {
        var errorMessage = $"originalFileName or Email not found in Metadata. Metadata.Count: {Metadata.Count}";
        log.LogError(errorMessage);
    }

    message = new SendGridMessage()
    {
        From = new EmailAddress("no-reply@em6295.andriicharkivskyi.online", "no-reply"),
        Subject = "Blob Trigger Email",
        PlainTextContent = messageText,
    };

    message.AddTo(emailTo);
}
