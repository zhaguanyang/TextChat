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
        public string Command { get; } = "chat";
        public string[] Aliases { get; } = Plugin.SharedConfig.Aliases?.ToArray() ?? new string[] { "chat" };
        public string Description { get; } = "Chat with other players";


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender))
            {
                response = "This command can only be ran by a player!";
                return true;
            }

            Player p = Player.Get(((PlayerCommandSender)sender).ReferenceHub);

            if (arguments.Count < 1)
            {
                response = "用法: .c <内容>";
                return true;
            }

            string message = string.Join(" ", arguments);

            string text = string.Format(Plugin.SharedConfig.MessageFormat, p.Nickname,
                message);

            Plugin.ChatMessages.Add(text);


            foreach (Player player in Player.List)
            {
                if (Plugin.SharedConfig.HistoryLength <= 1)
                    player.ShowManagedHint($"\n\n<align=left>{text}</align>", Plugin.SharedConfig.HintDuration, false, DisplayLocation.Top);
                else
                {
                    player.ShowManagedHint(
                        $"\n\n<align=left>{string.Join("\n", Plugin.ChatMessages.Skip(Math.Max(0, Plugin.ChatMessages.Count - Plugin.SharedConfig.HistoryLength)))}</align>",
                        Plugin.SharedConfig.HintDuration, true, DisplayLocation.Top);
                }
            }


            response = "消息已发送!";
            return true;
        }
    }
}