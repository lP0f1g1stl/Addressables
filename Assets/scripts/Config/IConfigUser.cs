using System.Collections.Generic;
using System.Threading.Tasks;
public interface IConfigUser
{

}
public interface IConfigManager 
{
    public Task GetConfig<TConfigType>(List<TConfigType> configs, ConfigType configType);
}