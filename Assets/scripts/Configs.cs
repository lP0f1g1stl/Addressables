using System.Collections.Generic;
using System;

[Serializable]
public struct Configs<TConfigType>
{
    public string assetLabel;
    public List<TConfigType> configs; 
}
