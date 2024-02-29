using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System;
public interface IConfigUser
{

}
public interface IConfigManager 
{
    public Action<float> OnProgressChange { get; set; }
    public UniTask LoadConfigs();
    public List<IConfig> GetConfig(ConfigType configType);
}