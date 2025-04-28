using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level20 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(275, 3.5f, 3.5f, "Spider LVL.20", 2980, Entity.Type.Spider));
        entities.Add(new Entity(280, 3.5f, 3.5f, "Frog LVL.20", 3060, Entity.Type.Frog));
        entities.Add(new Entity(285, 3.5f, 3.5f, "Bird LVL.20", 3140, Entity.Type.Bird));
        return entities;
    }
}
