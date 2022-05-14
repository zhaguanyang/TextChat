using System;
using Exiled.Events.EventArgs;
using Exiled.API.Features;
using MEC;


namespace SCPChat
{
    public class EventHandlers
    {
        public void OnWaitingForPlayers()
        {
            Plugin.ChatMessages.Clear();
            
        }
    }
}