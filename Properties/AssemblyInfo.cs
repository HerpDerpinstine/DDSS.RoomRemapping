using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(DDSS_RoomRemapping.Properties.BuildInfo.Description)]
[assembly: AssemblyDescription(DDSS_RoomRemapping.Properties.BuildInfo.Description)]
[assembly: AssemblyCompany(DDSS_RoomRemapping.Properties.BuildInfo.Company)]
[assembly: AssemblyProduct(DDSS_RoomRemapping.Properties.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + DDSS_RoomRemapping.Properties.BuildInfo.Author)]
[assembly: AssemblyTrademark(DDSS_RoomRemapping.Properties.BuildInfo.Company)]
[assembly: AssemblyVersion(DDSS_RoomRemapping.Properties.BuildInfo.Version)]
[assembly: AssemblyFileVersion(DDSS_RoomRemapping.Properties.BuildInfo.Version)]
[assembly: MelonInfo(typeof(DDSS_RoomRemapping.MelonMain), 
    DDSS_RoomRemapping.Properties.BuildInfo.Name, 
    DDSS_RoomRemapping.Properties.BuildInfo.Version,
    DDSS_RoomRemapping.Properties.BuildInfo.Author,
    DDSS_RoomRemapping.Properties.BuildInfo.DownloadLink)]
[assembly: MelonGame("StripedPandaStudios", "DDSS")]
[assembly: VerifyLoaderVersion("0.6.5", true)]
[assembly: HarmonyDontPatchAll]