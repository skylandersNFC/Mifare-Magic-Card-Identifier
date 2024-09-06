using LibnfcSharp;
using LibnfcSharp.Mifare;
using LibnfcSharp.Mifare.Extensions;
using LibnfcSharp.Mifare.Models;
using System;

namespace MifareMagicCardIdentifier
{
    internal class Program
    {
        private static readonly byte[] DEFAULT_KEY = new byte[6] { 0x4B, 0x0B, 0x20, 0x10, 0x7C, 0xCB };

        static void Main(string[] args)
        {
            Console.Title = $"Mifare Magic Card Identifier v{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}{ThisAssembly.Git.SemVer.DashLabel} [{ThisAssembly.Git.Commit}]";

            Console.WriteLine($$"""
                Place a card on the reader...

                """);

            do
            {
                using (var context = new NfcContext())
                using (var device = context.OpenDevice())
                {
                    var mfc = new MifareClassic(device);
                    mfc.RegisterKeyAProviderCallback((_, _) => DEFAULT_KEY);
                    mfc.InitialDevice();
                    mfc.WaitForCard();
                    mfc.IdentifyMagicCardType();

                    ManufacturerInfo manufacturerInfo;
                    mfc.ReadManufacturerInfo(out manufacturerInfo);

                    byte[] accessConditions;
                    var hasUnlockedAccessConditions = mfc.HasUnlockedAccessConditions(0, out accessConditions);

                    Console.WriteLine($$"""
                        UID: {{Convert.ToHexString(mfc.Uid)}}
                        BCC: {{Convert.ToHexString(new[] { manufacturerInfo.Bcc })}}
                        SAK: {{Convert.ToHexString(new[] { mfc.Sak })}} ({{Convert.ToHexString(new[] { manufacturerInfo.Sak })}})
                        ATQA: {{Convert.ToHexString(mfc.Atqa)}} ({{Convert.ToHexString(manufacturerInfo.Atqa)}})
                        ATS: {{(mfc.Ats.Length == 0 ? "-" : Convert.ToHexString(mfc.Ats))}}

                        Type: {{mfc.MagicCardType.ToDescription()}}
                        Access Conditions (Sector 0): {{Convert.ToHexString(accessConditions)}} ({{(hasUnlockedAccessConditions ? "unlocked" : "locked")}})

                        Press {ENTER} to identify a new card...


                        """);
                }
            }
            while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
    }
}
