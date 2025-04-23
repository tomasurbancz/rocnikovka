using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level1 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        /*entities.Add(new Entity(1, 3.5f, 3.5f, "Pták LVL.1", 10, Entity.Type.Bird));
        entities.Add(new Entity(5, 3.5f, 3.5f, "Pavouk LVL.1", 25, Entity.Type.Spider));
        entities.Add(new Entity(25, 3.5f, 3.5f, "Žába LVL.1", 100, Entity.Type.Frog));*/
        entities.Add(new Entity(1, 3.5f, 3.5f, "Pták LVL.1", 1, Entity.Type.Bird));
        entities.Add(new Entity(5, 3.5f, 3.5f, "Pavouk LVL.1", 1, Entity.Type.Spider));
        entities.Add(new Entity(25, 3.5f, 3.5f, "Žába LVL.1", 1, Entity.Type.Frog));
        return entities;
    }
}
