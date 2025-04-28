using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level1 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(2, 3.5f, 3.5f, "Myš LVL.1", 10, Entity.Type.Mouse));
        entities.Add(new Entity(6, 3.5f, 3.5f, "Pavouk LVL.1", 30, Entity.Type.Spider));
        entities.Add(new Entity(10, 3.5f, 3.5f, "Pták LVL.1", 50, Entity.Type.Bird));
        return entities;
    }
}
