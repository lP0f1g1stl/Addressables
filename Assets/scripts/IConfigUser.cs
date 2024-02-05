using System.Collections.Generic;
using System.Threading.Tasks;
public interface IConfigUser
{
    public void Init(IConfigManager manager);
}
public interface IConfigManager 
{
    public Task<List<TConfigType>> GetConfig<TConfigType>(List<TConfigType> configs, string label);
}