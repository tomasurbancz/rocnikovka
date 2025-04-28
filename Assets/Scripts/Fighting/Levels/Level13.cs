using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level13 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(170, 3.5f, 3.5f, "Mouse LVL.13", 1370, Entity.Type.Mouse));
        entities.Add(new Entity(175, 3.5f, 3.5f, "Spider LVL.13", 1440, Entity.Type.Spider));
        entities.Add(new Entity(180, 3.5f, 3.5f, "Frog LVL.13", 1510, Entity.Type.Frog));
        return entities;
    }
}
