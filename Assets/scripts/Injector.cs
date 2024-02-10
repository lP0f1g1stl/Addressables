using System.Collections.Generic;

public class Injector
{
    public Injector(List<IConfigUser> configUsers, IConfigManager configManager)
    {
        foreach (IConfigUser configUser in configUsers)
        {
            configUser.Init(configManager);
        }
    }
}
