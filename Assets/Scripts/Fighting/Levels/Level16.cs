using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level16 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(215, 3.5f, 3.5f, "Spider LVL.16", 2020, Entity.Type.Spider));
        entities.Add(new Entity(220, 3.5f, 3.5f, "Frog LVL.16", 2100, Entity.Type.Frog));
        entities.Add(new Entity(225, 3.5f, 3.5f, "Bird LVL.16", 2180, Entity.Type.Bird));
        return entities;
    }
}
