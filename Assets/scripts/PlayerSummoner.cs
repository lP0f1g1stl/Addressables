using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using Zenject;

public class PlayerSummoner : MonoBehaviour, IConfigUser
{
    [SerializeField] private ConfigType configType;
    [Space]
    [SerializeField] private Player prefab;
    
    private List<Player> players = new List<Player>();
    private List<PlayerConfig> configs = new List<PlayerConfig>();

    private IConfigManager manager;
    private IInputHandler inputHandler;

    [Inject]
    public void Construct(IConfigManager manager, IInputHandler inputHandler)
    {
        this.manager = manager;
        this.inputHandler = inputHandler;

        AddListener();
        FindPlayers();
        InstallConfig();
    }

    private void AddListener() 
    {
        inputHandler.OnSpawnPlayerBtnClick += SpawnPlayer;
    }

    private void OnDisable()
    {
        inputHandler.OnSpawnPlayerBtnClick -= SpawnPlayer;
    }

    private async Task InstallConfig()
    {
        Task task = manager.GetConfig(configs, configType);
        await task;
        SetData();
    }
    private void FindPlayers()
    {
        players.AddRange(FindObjectsOfType<Player>(true));
    }

    private void SetData()
    {
        if (players.Count != 0)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].PlayerSpeed = configs[Random.Range(0, configs.Count)].StartingSpeed;

            }
        }
    }
    private void SpawnPlayer()
    {
        Player player = Instantiate(prefab);
        player.PlayerSpeed = configs[Random.Range(0, configs.Count)].StartingSpeed;
        players.Add(player);
    }
}
