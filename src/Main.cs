using MelonLoader;
using UnityEngine;

namespace Nopjo
{
    public class ExtendedCasinoBets : MelonMod
    {
        private BetManager betManager;
        private BlackjackInterfaceMonitor interfaceMonitor;

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Extended Casino Bets started");
            betManager = new BetManager();
            interfaceMonitor = new BlackjackInterfaceMonitor();
            MelonLogger.Msg("Press F3 to decrease bet, F4 to increase bet. Available bets: " + betManager.GetBetAmountsString());

            MelonCoroutines.Start(SlotMachineModifier.ModifySlotMachineBets());
            MelonCoroutines.Start(interfaceMonitor.MonitorBlackjackInterface());
        }

        public override void OnUpdate()
        {
            try
            {
                var currentInterface = interfaceMonitor.GetCurrentBlackjackInterface();
                if (currentInterface != null && currentInterface.CurrentGame != null)
                {
                    if (Input.GetKeyDown(KeyCode.F4))
                    {
                        betManager.IncreaseBet(currentInterface);
                    }
                    else if (Input.GetKeyDown(KeyCode.F3))
                    {
                        betManager.DecreaseBet(currentInterface);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Error in OnUpdate: {ex.Message}");
            }
        }
    }
}