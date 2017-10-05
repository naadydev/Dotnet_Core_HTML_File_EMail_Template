[HttpGet]
public string Test()
{
    //-------------------
    var templatePath = $@"{Directory.GetCurrentDirectory()}\Contents\Emails\NewTask.html";
    System.Collections.Specialized.ListDictionary replacements = new System.Collections.Specialized.ListDictionary();
    replacements.Add("<%CreatedBy%>", "naadydev@gmail.com");
    replacements.Add("<%AssignedTo%>", "nadydev@outlook.com");
    replacements.Add("<%ReqDate%>", DateTime.Now.ToString("MMM ddd dd/MM/yyy hh:mm:ss"));
    replacements.Add("<%TaskUrl%>", $"http://Mysystem/CTM/Tasks/{taskId}");
    //-------------------
    _messageService.SendEmail("My Message Body", replacements, "New Task", "info@mysystem.com", "My System", "naadydev@gmail.com", "", "");
    _messageService.SendEmailUsingHTMLFileTemplate(templatePath, replacements, "New Task", "info@mysystem", "MAS CTM System", "naadydev@gmail.com", "", "");

    return "ok";
}