using HarmonyLib;
using Stonescript;
using System.Collections.Generic;
using System.Linq;

namespace StoneStoryQoL.Patches;

[HarmonyPatch(typeof(StonescriptGlobals), nameof(StonescriptGlobals.RegisterGameModel))]
public static class MoreStoneScript {
    [HarmonyPrefix]
    private static void RegNewCommands(Machine machine, AStonescriptGameModel gameModel) {
        machine.RegisterFunction("loc.restart", RestartQuest);

        machine.RegisterVariable("foe.wakeupTics", delegate {
            var targetEnemy3 = GameStates.Singleton.hero.GetComponent<HeroAI>().targetEnemy;
            return (targetEnemy3 != null) ? new int?(targetEnemy3.wakeupTics) : null;
        });
        machine.RegisterVariable("foe.IsAwake", delegate {
            var targetEnemy4 = GameStates.Singleton.hero.GetComponent<HeroAI>().targetEnemy;
            return (targetEnemy4 != null) ? new bool?(targetEnemy4.IsAwake()) : null;
        });
        machine.RegisterVariable("player.level", () => XPController.singleton.currentLevel);

        machine.RegisterFunction("treasure.openAll", TreasureOpen);
    }

    private static object RestartQuest(List<object> parameters, InvocationContext ctx) {
        var gameState = GameStates.Singleton;
        if (gameState.GetTotalTime() < 120) return false;
        var quest = gameState.parentQuest ?? gameState.level.QuestData;
        gameState.StartQuest(quest, true, true);
        return true;
    }

    private static object TreasureOpen(List<object> parameters, InvocationContext ctx) {
        if (Inventory.Singleton.GetTreasures().Count == 0 ||
            GameStates.Singleton.CurrentState        == GameStates.State.PlayItemScreen) {
            return null;
        }

        GameStates.Singleton.SetState(GameStates.State.PlayItemScreen);
        var treasures = Inventory.Singleton.GetTreasures();
        if (treasures.Count <= 0) return false;
        foreach (var treasure in treasures.Where(treasure => treasure != null)) {
            GameStates.Singleton.itemScreen.SetState(ItemScreen.State.OpeningTreasure);
            GameStates.Singleton.itemScreen.openTreasureDialog.Setup(treasure, true);
            GameStates.Singleton.itemScreen.openTreasureDialog.autoSkip = true;
            GameStates.Singleton.itemScreen.openTreasureDialog.Show();
            AnalyticsMacros.OpenTreasure(treasure);
        }

        GameStates.Singleton.SetState(GameStates.State.Playing);
        return true;
    }
}