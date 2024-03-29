#region Using

using Terraria;

using PacketManager;

#endregion

namespace WorldSceneAPI
{
    public class SceneTimeSetPacket : ScenePacket
    {
        #region Data

        public override PacketTypes Packet => PacketTypes.TimeSet;

        #endregion
        #region Constructor

        public SceneTimeSetPacket(WorldScene scene) : base(scene) { }

        #endregion

        #region PackBytes

        public override void PackBytes(PacketPackBytesArgs args)
        {
            args.writer.Write((byte)((LoadedScene.DayTime ?? Main.dayTime) ? 1 : 0));
            args.writer.Write((int)(LoadedScene.Time ?? Main.time));
            args.writer.Write(LoadedScene.SunModY ?? Main.sunModY);
            args.writer.Write(LoadedScene.MoonModY ?? Main.moonModY);
        }

        #endregion
    }
}
