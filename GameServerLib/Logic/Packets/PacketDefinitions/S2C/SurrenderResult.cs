using LeagueSandbox.GameServer.Logic.Enet;
using LeagueSandbox.GameServer.Logic.Packets.PacketHandlers;

namespace LeagueSandbox.GameServer.Logic.Packets.PacketDefinitions.S2C
{
    public class SurrenderResult : BasePacket
    {
        public SurrenderResult(Game game, bool reason, int yes, int no, TeamId team)
            : base(game, PacketCmd.PKT_S2C_SURRENDER_RESULT)
        {
            Write(reason); //surrendererNetworkId
            Write((byte)yes); //yesVotes
            Write((byte)no); //noVotes
            Write((int)team); //team
        }
    }
}