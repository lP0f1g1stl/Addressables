using System.Collections.Generic;
using System.Threading.Tasks;
public interface IConfigUser
{

}
public interface IConfigManager 
{
    public Task LoadConfigs();
    public List<IConfig> GetConfig(ConfigType configType);
}