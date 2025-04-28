using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level9 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(110, 3.5f, 3.5f, "Mouse LVL.9", 670, Entity.Type.Mouse));
        entities.Add(new Entity(115, 3.5f, 3.5f, "Spider LVL.9", 720, Entity.Type.Spider));
        entities.Add(new Entity(120, 3.5f, 3.5f, "Frog LVL.9", 760, Entity.Type.Frog));
        return entities;
    }
}
