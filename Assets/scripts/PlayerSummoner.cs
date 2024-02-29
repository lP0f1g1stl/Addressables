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
    private PauseManager pauseManager;

    [Inject]
    public void Construct(IConfigManager manager, IInputHandler inputHandler, PauseManager pauseManager)
    {
        this.manager = manager;
        this.inputHandler = inputHandler;
        this.pauseManager = pauseManager;

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

    private void InstallConfig()
    {
        configs = manager.GetConfig(ConfigType.Player).ConvertAll(x => (PlayerConfig)x);
        SetData();
    }
    private void FindPlayers()
    {
        players.AddRange(FindObjectsOfType<Player>(true));

        foreach(Player player in players) 
        {
            pauseManager.AddPausable(player);
        }
    }

    private void SetData()
    {
        if (players.Count != 0)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].PlayerConfig = configs[Random.Range(0, configs.Count)];

            }
        }
    }
    private void SpawnPlayer()
    {
        Player player = Instantiate(prefab);
        player.PlayerConfig = configs[Random.Range(0, configs.Count)];
        players.Add(player);
        pauseManager.AddPausable(player);
    }
}
