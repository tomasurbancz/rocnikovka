using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level17 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(230, 3.5f, 3.5f, "Mouse LVL.17", 2260, Entity.Type.Mouse));
        entities.Add(new Entity(235, 3.5f, 3.5f, "Spider LVL.17", 2340, Entity.Type.Spider));
        entities.Add(new Entity(240, 3.5f, 3.5f, "Frog LVL.17", 2420, Entity.Type.Frog));
        return entities;
    }
}
