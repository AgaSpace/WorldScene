#region Using

using Terraria;
using Terraria.Social;
using Terraria.GameContent.Events;

using PacketManager;

#endregion

namespace WorldSceneAPI
{
    public class SceneWorldInfoPacket : ScenePacket
    {
        #region Data

        public override PacketTypes Packet => PacketTypes.WorldInfo;

        #endregion
        #region Constructor

        public SceneWorldInfoPacket(WorldScene scene) : base(scene) { }

        #endregion

        #region PackBytes

        public override void PackBytes(PacketPackBytesArgs args)
        {
            args.writer.Write((int)(LoadedScene.Time ?? Main.time));
            BitsByte bb = new BitsByte(LoadedScene.DayTime ?? Main.dayTime,
                LoadedScene.BloodMoon ?? Main.bloodMoon, LoadedScene.Eclipse ?? Main.eclipse);
            args.writer.Write(bb);

            args.writer.Write((byte)(LoadedScene.MoonPhase ?? Main.moonPhase));
            if (LoadedScene.MaxTiles.HasValue)
            {
                args.writer.Write((short)LoadedScene.MaxTiles.Value.X);
                args.writer.Write((short)LoadedScene.MaxTiles.Value.Y);
            }
            else
            {
                args.writer.Write((short)Main.maxTilesX);
                args.writer.Write((short)Main.maxTilesY);
            }

            if (LoadedScene.SpawnTile.HasValue)
            {
                args.writer.Write((short)LoadedScene.SpawnTile.Value.X);
                args.writer.Write((short)LoadedScene.SpawnTile.Value.Y);
            }
            else
            {
                args.writer.Write((short)Main.spawnTileX);
                args.writer.Write((short)Main.spawnTileY);
            }

            args.writer.Write((short)(LoadedScene.WorldSurface ?? Main.worldSurface));
            args.writer.Write((short)(LoadedScene.RockLayer ?? Main.rockLayer));

            args.writer.Write(LoadedScene.CustomWorldID ?? Main.worldID);
            args.writer.Write(LoadedScene.WorldName ?? Main.worldName);
            args.writer.Write((byte)(LoadedScene.GameMode ?? Main.GameMode));

            args.writer.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
            args.writer.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);

            args.writer.Write((byte)(LoadedScene.MoonType ?? Main.moonType));
            args.writer.Write((byte)(LoadedScene.TreeBG1 ?? WorldGen.treeBG1));
            args.writer.Write((byte)(LoadedScene.TreeBG2 ?? WorldGen.treeBG2));
            args.writer.Write((byte)(LoadedScene.TreeBG3 ?? WorldGen.treeBG3));
            args.writer.Write((byte)(LoadedScene.TreeBG4 ?? WorldGen.treeBG4));
            args.writer.Write((byte)(LoadedScene.CorruptBG ?? WorldGen.corruptBG));
            args.writer.Write((byte)(LoadedScene.JungleBG ?? WorldGen.jungleBG));
            args.writer.Write((byte)(LoadedScene.SnowBG ?? WorldGen.snowBG));
            args.writer.Write((byte)(LoadedScene.HallowBG ?? WorldGen.hallowBG));
            args.writer.Write((byte)(LoadedScene.CrimsonBG ?? WorldGen.crimsonBG));
            args.writer.Write((byte)(LoadedScene.DesertBG ?? WorldGen.desertBG));
            args.writer.Write((byte)(LoadedScene.OceanBG ?? WorldGen.oceanBG));
            args.writer.Write((byte)(LoadedScene.MushroomBG ?? WorldGen.mushroomBG));
            args.writer.Write((byte)(LoadedScene.UnderworldBG ?? WorldGen.underworldBG));

            args.writer.Write((byte)(LoadedScene.IceBackStyle ?? Main.iceBackStyle));
            args.writer.Write((byte)(LoadedScene.JungleBackStyle ?? Main.jungleBackStyle));
            args.writer.Write((byte)(LoadedScene.HellBackStyle ?? Main.hellBackStyle));
            args.writer.Write(LoadedScene.WindSpeedTarget ?? Main.windSpeedTarget);
            args.writer.Write((byte)(LoadedScene.NumClouds ?? Main.numClouds));

            for (int i = 0; i < 3; i++)
                args.writer.Write(LoadedScene.TreeX[i] ?? Main.treeX[i]);
            //args.writer.Write(Main.treeX[i]);
            for (int i = 0; i < 4; i++)
                args.writer.Write((byte)(LoadedScene.TreeStyle[i] ?? Main.treeStyle[i]));
            //args.writer.Write((byte)Main.treeStyle[i]);
            for (int i = 0; i < 3; i++)
                args.writer.Write(LoadedScene.CaveBackX[i] ?? Main.caveBackX[i]);
            //args.writer.Write(Main.caveBackX[i]);
            for (int i = 0; i < 4; i++)
                args.writer.Write((byte)(LoadedScene.CaveBackStyle[i] ?? Main.caveBackStyle[i]));
            //args.writer.Write((byte)Main.caveBackStyle[i]);

            WorldGen.TreeTops.SyncSend(args.writer);
            if (!Main.raining)
                Main.maxRaining = 0f;
            args.writer.Write(LoadedScene.MaxRaining ?? Main.maxRaining);

            bb = new BitsByte(WorldGen.shadowOrbSmashed, NPC.downedBoss1, NPC.downedBoss2, NPC.downedBoss3,
                LoadedScene.HardMode ?? Main.hardMode, NPC.downedClown, LoadedScene.ServerSideCharacter ?? Main.ServerSideCharacter, NPC.downedPlantBoss);
            args.writer.Write(bb);
            bb = new BitsByte(NPC.downedMechBoss1, NPC.downedMechBoss2, NPC.downedMechBoss3, NPC.downedMechBossAny,
                (LoadedScene.CloudBackGroundActive ?? Main.cloudBGActive) >= 1f, WorldGen.crimson,
                    LoadedScene.PumpkinMoon ?? Main.pumpkinMoon, LoadedScene.SnowMoon ?? Main.snowMoon);
            args.writer.Write(bb);
            bb = new BitsByte(false, Main.fastForwardTimeToDawn, LoadedScene.SlimeRain ?? Main.slimeRain, NPC.downedSlimeKing,
                NPC.downedQueenBee, NPC.downedFishron, NPC.downedMartians, NPC.downedAncientCultist);
            args.writer.Write(bb);
            bb = new BitsByte(NPC.downedMoonlord, NPC.downedHalloweenKing, NPC.downedHalloweenTree,
                NPC.downedChristmasIceQueen, NPC.downedChristmasSantank, NPC.downedChristmasTree,
                NPC.downedGolemBoss, LoadedScene.PartyIsUp ?? BirthdayParty.PartyIsUp);
            args.writer.Write(bb);
            bb = new BitsByte(NPC.downedPirates, NPC.downedFrost, NPC.downedGoblins,
                LoadedScene.SandstormHappening ?? Sandstorm.Happening, DD2Event.Ongoing, DD2Event.DownedInvasionT1, DD2Event.DownedInvasionT2, DD2Event.DownedInvasionT3);
            args.writer.Write(bb);
            bb = new BitsByte(NPC.combatBookWasUsed, LoadedScene.LanternsUp ?? LanternNight.LanternsUp,
                NPC.downedTowerSolar, NPC.downedTowerVortex, NPC.downedTowerNebula, NPC.downedTowerStardust,
                Main.forceHalloweenForToday, Main.forceXMasForToday);
            args.writer.Write(bb);
            bb = new BitsByte(NPC.boughtCat, NPC.boughtDog, NPC.boughtBunny, NPC.freeCake, Main.drunkWorld,
                NPC.downedEmpressOfLight, NPC.downedQueenSlime, Main.getGoodWorld);
            args.writer.Write(bb);
            bb = new BitsByte(LoadedScene.TenthAnniversaryWorld ?? Main.tenthAnniversaryWorld,
                LoadedScene.DontStarveWorld ?? Main.dontStarveWorld, NPC.downedDeerclops,
                LoadedScene.NotTheBeesWorld ?? Main.notTheBeesWorld, LoadedScene.RemixWorld ?? Main.remixWorld,
                NPC.unlockedSlimeBlueSpawn, NPC.combatBookVolumeTwoWasUsed, NPC.peddlersSatchelWasUsed);
            args.writer.Write(bb);
            bb = new BitsByte(NPC.unlockedSlimeGreenSpawn, NPC.unlockedSlimeOldSpawn,
                NPC.unlockedSlimePurpleSpawn, NPC.unlockedSlimeRainbowSpawn, NPC.unlockedSlimeRedSpawn,
                NPC.unlockedSlimeYellowSpawn, NPC.unlockedSlimeCopperSpawn, Main.fastForwardTimeToDusk);
            args.writer.Write(bb);
            bb = new BitsByte(LoadedScene.NoTrapsWorld ?? Main.noTrapsWorld, LoadedScene.ZenithWorld ?? Main.zenithWorld,
                NPC.unlockedTruffleSpawn);
            args.writer.Write(bb);

            args.writer.Write((byte)Main.sundialCooldown);
            args.writer.Write((byte)Main.moondialCooldown);
            args.writer.Write((short)WorldGen.SavedOreTiers.Copper);
            args.writer.Write((short)WorldGen.SavedOreTiers.Iron);
            args.writer.Write((short)WorldGen.SavedOreTiers.Silver);
            args.writer.Write((short)WorldGen.SavedOreTiers.Gold);
            args.writer.Write((short)WorldGen.SavedOreTiers.Cobalt);
            args.writer.Write((short)WorldGen.SavedOreTiers.Mythril);
            args.writer.Write((short)WorldGen.SavedOreTiers.Adamantite);
            args.writer.Write((sbyte)(LoadedScene.InvasionType ?? Main.invasionType));

            if (SocialAPI.Network != null)
                args.writer.Write(SocialAPI.Network.GetLobbyId());
            else
                args.writer.Write(0uL);
            args.writer.Write(LoadedScene.SandstormIntendedSeverity ?? Sandstorm.IntendedSeverity);
        }

        #endregion
    }
}
