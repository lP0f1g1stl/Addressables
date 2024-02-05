using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PlayerSummoner : MonoBehaviour, IConfigUser
{
    [SerializeField] private string label;
    [Space]
    [SerializeField] private Player prefab;
    
    private List<Player> players = new List<Player>();
    private List<PlayerConfig> configs = new List<PlayerConfig>();

    private IConfigManager manager;

    public void Init(IConfigManager manager)
    {
        this.manager = manager;
    }
    private void Start()
    {
        FindPlayers();
        InstallConfig();
    }

    private async void InstallConfig() 
    {
        Task<List<PlayerConfig>> task = manager.GetConfig(configs, label);
        await task;
        configs = task.Result;
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
                players[i].StartingSpeed = configs[Random.Range(0, configs.Count)].StartingSpeed;

            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Player player = Instantiate(prefab);
            player.StartingSpeed = configs[Random.Range(0, configs.Count)].StartingSpeed;
            players.Add(player);
        }
    }
}
