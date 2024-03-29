#region Using

using PacketManager;

#endregion

namespace WorldSceneAPI
{
    public abstract class ScenePacket : PacketBuilder
    {
        #region Data

        public WorldScene LoadedScene;

        #endregion
        #region Constructor

        public ScenePacket(WorldScene scene)
        {
            LoadedScene = scene;
        }

        #endregion
    }
}
