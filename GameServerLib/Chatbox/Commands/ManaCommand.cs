﻿using ENet;
using LeagueSandbox.GameServer.Players;

namespace LeagueSandbox.GameServer.Chatbox.Commands
{
    class ManaCommand : ChatCommand
    {
        public ManaCommand(string command, string syntax, ChatCommandManager owner) : base(command, syntax, owner) { }

        public override void Execute(Peer peer, bool hasReceivedArguments, string arguments = "")
        {
            var playerManager = Program.ResolveDependency<PlayerManager>();

            var split = arguments.ToLower().Split(' ');
            float mp;
            if (split.Length < 2)
            {
                _owner.SendDebugMsgFormatted(ChatCommandManager.DebugMsgType.SyntaxError);
                ShowSyntax();
            }
            else if (float.TryParse(split[1], out mp))
            {
                playerManager.GetPeerInfo(peer).Champion.GetStats().ManaPoints.FlatBonus = mp;
                playerManager.GetPeerInfo(peer).Champion.GetStats().CurrentMana = mp;
            }
        }
    }
}