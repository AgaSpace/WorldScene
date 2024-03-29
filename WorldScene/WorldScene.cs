#region Using

using Newtonsoft.Json;

using Microsoft.Xna.Framework;

using Terraria;

using PacketManager;
using TShockAPI;

#endregion

namespace WorldSceneAPI
{
    public class WorldScene : IDisposable
    {
        #region Data

        [JsonIgnore]
        public WorldScene? parent;
        [JsonIgnore]
        protected List<PacketBuilder> _builders;
        [JsonIgnore]
        protected List<PlayerPacketManager> _players;

        #endregion
        #region Constructor

        public WorldScene()
        {
            if (Main.curRelease != 279)
                throw new ArgumentException("The plugin may not work on different versions.");
            _builders = new List<PacketBuilder>
            {
                new SceneWorldInfoPacket(this), new SceneTimeSetPacket(this)
            };
            _players = new();
        }

        #endregion
        #region Dispose

        public virtual void Dispose()
        {
            foreach (PlayerPacketManager manager in _players.ToList())
                Remove(manager);
        }

        #endregion

        #region Add

        public virtual bool Add(TSPlayer player)
        {
            return Add(PacketManagerAPI.Players[player.Index]);
        }
        public virtual bool Add(int whoAmI)
        {
            return Add(PacketManagerAPI.Players[whoAmI]);
        }
        public virtual bool Add(byte whoAmI)
        {
            return Add(PacketManagerAPI.Players[whoAmI]);
        }
        public virtual bool Add(PlayerPacketManager manager)
        {
            if (!_players.Contains(manager))
            {
                _players.Add(manager);
                foreach (PacketBuilder builder in _builders)
                    manager.Add(builder);
                return true;
            }

            return false;
        }

        #endregion
        #region Remove

        public virtual bool Remove(TSPlayer player)
        {
            return Remove(PacketManagerAPI.Players[player.Index]);
        }
        public virtual bool Remove(int whoAmI)
        {
            return Remove(PacketManagerAPI.Players[whoAmI]);
        }
        public virtual bool Remove(byte whoAmI)
        {
            return Remove(PacketManagerAPI.Players[whoAmI]);
        }
        public virtual bool Remove(PlayerPacketManager manager)
        {
            if (_players.Contains(manager))
            {
                _players.Remove(manager);
                foreach (PacketBuilder builder in _builders)
                    manager.Remove(builder);
                return true;
            }

            return false;
        }

        #endregion

        #region Properties

        [JsonIgnore]
        public int? Time { get => _time ?? parent?.Time; set { _time = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private int? _time;
        [JsonIgnore]
        public bool? DayTime { get => _daytime ?? parent?.DayTime; set { _daytime = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _daytime;
        [JsonIgnore]
        public short? SunModY { get => _sunmody ?? parent?.SunModY; set { _sunmody = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private short? _sunmody;
        [JsonIgnore]
        public short? MoonModY { get => _moonmody ?? parent?.MoonModY; set { _moonmody = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private short? _moonmody;
        [JsonIgnore]
        public bool? BloodMoon { get => _bloodmoon ?? parent?.BloodMoon; set { _bloodmoon = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _bloodmoon;
        [JsonIgnore]
        public bool? Eclipse { get => _eclipse ?? parent?.Eclipse; set { _eclipse = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _eclipse;
        [JsonIgnore]
        public byte? MoonPhase { get => _moonphase ?? parent?.MoonPhase; set { _moonphase = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _moonphase;
        [JsonIgnore]
        public Point? MaxTiles { get => _maxtiles ?? parent?.MaxTiles; set { _maxtiles = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private Point? _maxtiles;
        [JsonIgnore]
        public Point? SpawnTile { get => _spawntile ?? parent?.SpawnTile; set { _spawntile = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private Point? _spawntile;
        [JsonIgnore]
        public short? WorldSurface { get => _worldsurface ?? parent?.WorldSurface; set { _worldsurface = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private short? _worldsurface;
        [JsonIgnore]
        public short? RockLayer { get => _rocklayer ?? parent?.RockLayer; set { _rocklayer = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private short? _rocklayer;
        [JsonIgnore]
        public int? CustomWorldID { get => _worldid ?? parent?.CustomWorldID; set { _worldid = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private int? _worldid;
        [JsonIgnore]
        public string? WorldName { get => _worldname ?? parent?.WorldName; set { _worldname = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private string? _worldname;
        [JsonIgnore]
        public byte? GameMode { get => _gamemode ?? parent?.GameMode; set { _gamemode = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _gamemode;
        [JsonIgnore]
        public byte? MoonType { get => _moontype ?? parent?.MoonType; set { _moontype = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _moontype;
        [JsonIgnore]
        public byte? TreeBG1 { get => _treebg1 ?? parent?.TreeBG1; set { _treebg1 = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _treebg1;
        [JsonIgnore]
        public byte? TreeBG2 { get => _treebg2 ?? parent?.TreeBG2; set { _treebg2 = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _treebg2;
        [JsonIgnore]
        public byte? TreeBG3 { get => _treebg3 ?? parent?.TreeBG3; set { _treebg3 = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _treebg3;
        [JsonIgnore]
        public byte? TreeBG4 { get => _treebg4 ?? parent?.TreeBG4; set { _treebg4 = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _treebg4;
        [JsonIgnore]
        public byte? CorruptBG { get => _corruptbg ?? parent?.CorruptBG; set { _corruptbg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _corruptbg;
        [JsonIgnore]
        public byte? JungleBG { get => _junglebg ?? parent?.JungleBG; set { _junglebg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _junglebg;
        [JsonIgnore]
        public byte? SnowBG { get => _snowbg ?? parent?.SnowBG; set { _snowbg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _snowbg;
        [JsonIgnore]
        public byte? HallowBG { get => _hallowbg ?? parent?.HallowBG; set { _hallowbg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _hallowbg;
        [JsonIgnore]
        public byte? CrimsonBG { get => _crimsonbg ?? parent?.CrimsonBG; set { _crimsonbg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _crimsonbg;
        [JsonIgnore]
        public byte? DesertBG { get => _desertbg ?? parent?.DesertBG; set { _desertbg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _desertbg;
        [JsonIgnore]
        public byte? OceanBG { get => _oceanbg ?? parent?.OceanBG; set { _oceanbg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _oceanbg;
        [JsonIgnore]
        public byte? MushroomBG { get => _mushroombg ?? parent?.MushroomBG; set { _mushroombg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _mushroombg;
        [JsonIgnore]
        public byte? UnderworldBG { get => _underworldbg ?? parent?.UnderworldBG; set { _underworldbg = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _underworldbg;
        [JsonIgnore]
        public byte? IceBackStyle { get => _icebackstyle ?? parent?.IceBackStyle; set { _icebackstyle = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _icebackstyle;
        [JsonIgnore]
        public byte? JungleBackStyle { get => _junglebackstyle ?? parent?.JungleBackStyle; set { _junglebackstyle = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _junglebackstyle;
        [JsonIgnore]
        public byte? HellBackStyle { get => _hellbackstyle ?? parent?.HellBackStyle; set { _hellbackstyle = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _hellbackstyle;
        [JsonIgnore]
        public float? WindSpeedTarget { get => _windspeedtarget ?? parent?.WindSpeedTarget; set { _windspeedtarget = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private float? _windspeedtarget;
        [JsonIgnore]
        public byte? NumClouds { get => _numclouds ?? parent?.NumClouds; set { _numclouds = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private byte? _numclouds;

        [JsonIgnore]
        public int?[] TreeX { get => _treex; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private readonly int?[] _treex = new int?[Main.treeX.Length];
        [JsonIgnore]
        public int?[] TreeStyle { get => _treestyle; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private readonly int?[] _treestyle = new int?[Main.treeX.Length];
        [JsonIgnore]
        public int?[] CaveBackX { get => _cavebackx; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private readonly int?[] _cavebackx = new int?[Main.treeX.Length];
        [JsonIgnore]
        public int?[] CaveBackStyle { get => _cavebackstyle; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private readonly int?[] _cavebackstyle = new int?[Main.treeX.Length];

        [JsonIgnore]
        public float? MaxRaining { get => _maxraining ?? parent?.MaxRaining; set { _maxraining = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private float? _maxraining;
        [JsonIgnore]
        public bool? HardMode { get => _hardmode ?? parent?.HardMode; set { _hardmode = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _hardmode;
        [JsonIgnore]
        public bool? ServerSideCharacter { get => _serversidecharacter ?? parent?.ServerSideCharacter; set { _serversidecharacter = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _serversidecharacter;
        [JsonIgnore]
        public float? CloudBackGroundActive { get => _cloudbackgroundactive ?? parent?.CloudBackGroundActive; set { _cloudbackgroundactive = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private float? _cloudbackgroundactive;
        [JsonIgnore]
        public bool? PumpkinMoon { get => _pumpkinmoon ?? parent?.PumpkinMoon; set { _pumpkinmoon = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _pumpkinmoon;
        [JsonIgnore]
        public bool? SnowMoon { get => _snowmoon ?? parent?.SnowMoon; set { _snowmoon = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _snowmoon;
        [JsonIgnore]
        public bool? SlimeRain { get => _slimerain ?? parent?.SlimeRain; set { _slimerain = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _slimerain;
        [JsonIgnore]
        public bool? PartyIsUp { get => _partyisup ?? parent?.PartyIsUp; set { _partyisup = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _partyisup;
        [JsonIgnore]
        public bool? SandstormHappening { get => _sandstormhappening ?? parent?.SandstormHappening; set { _sandstormhappening = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _sandstormhappening;
        [JsonIgnore]
        public float? SandstormIntendedSeverity { get => _sandstormintendedseverity ?? parent?.SandstormIntendedSeverity; set { _sandstormintendedseverity = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private float? _sandstormintendedseverity;
        [JsonIgnore]
        public bool? LanternsUp { get => _lanternsup ?? parent?.LanternsUp; set { _lanternsup = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _lanternsup;
        [JsonIgnore]
        public bool? TenthAnniversaryWorld { get => _tenthanniversaryworld ?? parent?.TenthAnniversaryWorld; set { _tenthanniversaryworld = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _tenthanniversaryworld;
        [JsonIgnore]
        public bool? DontStarveWorld { get => _dontstarveworld ?? parent?.DontStarveWorld; set { _dontstarveworld = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _dontstarveworld;
        [JsonIgnore]
        public bool? NotTheBeesWorld { get => _notthebeesworld ?? parent?.NotTheBeesWorld; set { _notthebeesworld = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _notthebeesworld;
        [JsonIgnore]
        public bool? RemixWorld { get => _remixworld ?? parent?.RemixWorld; set { _remixworld = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _remixworld;
        [JsonIgnore]
        public bool? NoTrapsWorld { get => _notrapsworld ?? parent?.NoTrapsWorld; set { _notrapsworld = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _notrapsworld;
        [JsonIgnore]
        public bool? ZenithWorld { get => _zenithworld ?? parent?.ZenithWorld; set { _zenithworld = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private bool? _zenithworld;
        [JsonIgnore]
        public sbyte? InvasionType { get => _invasiontype ?? parent?.InvasionType; set { _invasiontype = value; } }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private sbyte? _invasiontype;

        #endregion
    }
}
