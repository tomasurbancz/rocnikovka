using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInfo
{
    private string _header;
    private string _info;

    public MissionInfo (string header, string info)
    {
        _header = header;
        _info = info;
    }

    public string GetHeader()
    {
        return _header;
    }

    public string GetInfo()
    {
        return _info;
    }
}
