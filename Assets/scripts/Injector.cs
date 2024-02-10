using System.Collections.Generic;

public class Injector
{
    private List<IConfigUser> configUsers = new List<IConfigUser>();
    private IConfigManager configManager;
    public Injector(List<IConfigUser> configUsers, IConfigManager configManager)
    {
        this.configUsers = configUsers;
        this.configManager = configManager;
    }

    public void PerformInject() 
    {
        foreach(IConfigUser configUser in configUsers) 
        {
            configUser.Init(configManager);
        }
    }
}
