using Utils;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class SceneContext : Singleton<SceneContext>
    {
        public Player Player { get; private set; }

        public void RegisterPlayer(Player player)
        {
            if (this.Player != null)
            {
                LogHelper.LogWarning($"Attempted to register a second Player instance. Existing: {this.Player.name}, New: {player.name} - New player ignored.");
                return;
            }
            this.Player = player;
        }
    }
}
