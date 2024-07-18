using GTA;
using GTA.Math;
using GTA.Native;
using System;

namespace NoNPC
{
    public class Main : Script
    {
        public Main()
        {
            Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
            Wait(0);

            // Stop Spawn
            Function.Call(Hash.SET_CREATE_RANDOM_COPS, false);
            Function.Call(Hash.SET_CREATE_RANDOM_COPS_NOT_ON_SCENARIOS, false);
            Function.Call(Hash.SET_CREATE_RANDOM_COPS_ON_SCENARIOS, false);
            Function.Call(Hash.SET_GARBAGE_TRUCKS, false);
            Function.Call(Hash.SET_RANDOM_BOATS, false);
            Function.Call(Hash.SET_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.0f);
            Function.Call(Hash.SET_PED_DENSITY_MULTIPLIER_THIS_FRAME, 0.0f);
            Function.Call(Hash.SET_RANDOM_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.0f);
            Function.Call(Hash.SET_SCENARIO_PED_DENSITY_MULTIPLIER_THIS_FRAME, 0.0f, 0.0f);
            Function.Call(Hash.SET_PARKED_VEHICLE_DENSITY_MULTIPLIER_THIS_FRAME, 0.0f);

            // Prevent Firefighters and other Services to spawn
            for (int i = 1; i <= 12; i++)
            {
                Function.Call(Hash.ENABLE_DISPATCH_SERVICE, i, false);
            }

            // Clear NPC
            Vector3 coords = Game.Player.Character.Position;
            Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, coords.X, coords.Y, coords.Z, 1000, false, false, false, false, false);
            Function.Call(Hash.REMOVE_VEHICLES_FROM_GENERATORS_IN_AREA, coords.X - 500.0, coords.Y - 500.0, coords.Z - 500.0, coords.X + 500.0, coords.Y + 500.0, coords.Z + 500.0);
        }
    }
}
