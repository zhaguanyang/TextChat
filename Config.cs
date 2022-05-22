using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCPChat
{
    public class Config : IConfig
    {
        [Description("If plugin is enabled")] public bool IsEnabled { get; set; } = true;
        [Description("Aliases for the chat command")] public List<string> Aliases { get; set; } = new List<string>() { "c", "sc", "chat"};
        [Description("Formatting of the message")] public string MessageFormat { get; set; } = "{0}: {1}";
        [Description("How long the hint will be displayed for")] public int HintDuration { get; set; } = 7;
        [Description("Message history length")] public int HistoryLength { get; set; } = 1;
    }
}