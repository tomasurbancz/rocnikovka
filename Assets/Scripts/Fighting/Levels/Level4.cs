using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level4 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(35, 3.5f, 3.5f, "Pavouk LVL.4", 160, Entity.Type.Spider));
        entities.Add(new Entity(40, 3.5f, 3.5f, "Žába LVL.4", 180, Entity.Type.Frog));
        entities.Add(new Entity(45, 3.5f, 3.5f, "Pták LVL.4", 200, Entity.Type.Bird));
        return entities;
    }
}
