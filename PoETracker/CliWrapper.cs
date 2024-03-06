using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

class CliWrapper
{
    //TODO: Check if its possible to auto scan for Client.exe
    record OS
    {
        public record Linux() : OS();

        public record MacOSX() : OS();

        public record Windows() : OS();

        public record FreeBSD() : OS();

        public bool getOS()
        {
            return this switch
            {
                Linux linux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux),
                MacOSX maxosx => RuntimeInformation.IsOSPlatform(OSPlatform.OSX),
                Windows windows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows),
                FreeBSD freebsd => RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD),
                _ => false,
            };
        }

        private OS() { }
    }
}
