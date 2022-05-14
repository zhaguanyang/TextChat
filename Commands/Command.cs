using CommandSystem;
using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;
using RemoteAdmin;
using AdvancedHints;
using AdvancedHints.Enums;

namespace SCPChat.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class ChatCommand : ICommand
    {
        public string Command { get; } = "scpchat";
        public string[] Aliases { get; } = Plugin.SharedConfig.Aliases?.ToArray() ?? new string[] { "chat" };
        public string Description { get; } = "Chat with other SCPs";


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender))
            {
                response = "This command can only be ran by a player!";
                return true;
            }

            Player p = Player.Get(((PlayerCommandSender)sender).ReferenceHub);

            if (p.Role.Side != Side.Scp)
            {
                response = "This command can only be ran by an SCP!";
                return true;
            }

            if (arguments.Count < 1)
            {
                response = "Usage: .scpchat <message>";
                return true;
            }

            string message = string.Join(" ", arguments);

            string text = string.Format(Plugin.SharedConfig.MessageFormat, p.Role.ToFormattedString(), p.Nickname,
                message);

            Plugin.ChatMessages.Add(text);


            foreach (Player scp in Player.Get(Team.SCP).ToList())
            {
                if (Plugin.SharedConfig.HistoryLength <= 1)
                    scp.ShowManagedHint($"\n\n<align=left>{text}</align>", Plugin.SharedConfig.HintDuration, false, DisplayLocation.Top);
                else
                {
                    scp.ShowManagedHint(
                        $"\n\n<align=left>{string.Join("\n", Plugin.ChatMessages.Skip(Math.Max(0, Plugin.ChatMessages.Count - Plugin.SharedConfig.HistoryLength)))}</align>",
                        Plugin.SharedConfig.HintDuration, true, DisplayLocation.Top);
                }
            }


            response = "Message has been sent!";
            return true;
        }
    }
}