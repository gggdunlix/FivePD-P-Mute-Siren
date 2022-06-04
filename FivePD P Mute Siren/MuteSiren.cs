using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;
using CitizenFX.Core.Native;

namespace mutesiren
{
    public class mutesiren
    {
        public class Plugin : FivePD.API.Plugin
        {
            public bool muted;
            internal Plugin()
            {
                Tick += Command;


            }

            public async Task Command()
            {
                if (Game.PlayerPed.IsInVehicle())
                {
                    await Delay(3000);
                    muted = false;
                    Vehicle pvehicle = Game.PlayerPed.CurrentVehicle;
                    var vehiclename = Game.PlayerPed.CurrentVehicle.DisplayName.ToLower();
                    API.RegisterCommand("togglesirensound", new Action<bool>((mute) =>
                    {
                        if (pvehicle.HasSiren)
                        {
                            if (muted)
                            {
                                pvehicle.IsSirenSilent = false;
                                muted = false;

                            }
                            else if (!muted)
                            {
                                pvehicle.IsSirenSilent = true;
                                muted = true;
                            }
                        }
                    }), false /*This command is also not restricted, anyone can use it.*/ );
                }
                API.RegisterKeyMapping("togglesirensound", "Mutes the siren on you current Vehicle", "keyboard", "n");
            }

        }
    }
}
