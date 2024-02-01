using UnityEngine;
using System.Collections.Generic;

public class PlayerSummoner : MonoBehaviour
{
    [SerializeField] private Player prefab;

    [SerializeField] private List<Player> players;

    private void Start()
    {
        if(ConfigManager.instance != null) ConfigManager.instance.OnLoadDone += FindPlayers;
    }
    private void OnDisable()
    {
        if (ConfigManager.instance != null) ConfigManager.instance.OnLoadDone -= FindPlayers;
    }
    private void FindPlayers(int queueIndex)
    {
        if (queueIndex == 0)
        {
            players.AddRange(FindObjectsOfType<Player>());
            if (players.Count != 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    players[i].StartingSpeed = ConfigManager.instance.PlayerConfigs.configs[Random.Range(0, ConfigManager.instance.PlayerConfigs.configs.Count)].StartingSpeed;

                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Player player = Instantiate(prefab);
            players.Add(player);
            if (ConfigManager.instance != null) player.StartingSpeed = ConfigManager.instance.PlayerConfigs.configs[Random.Range(0, ConfigManager.instance.PlayerConfigs.configs.Count)].StartingSpeed;
        }
    }
}
