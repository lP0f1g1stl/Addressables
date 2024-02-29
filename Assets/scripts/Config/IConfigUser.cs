using System.Collections.Generic;
using Cysharp.Threading.Tasks;
public interface IConfigUser
{

}
public interface IConfigManager 
{
    public UniTask LoadConfigs();
    public List<IConfig> GetConfig(ConfigType configType);
}