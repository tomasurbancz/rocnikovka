using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level2 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(12, 3.5f, 3.5f, "Žába LVL.2", 60, Entity.Type.Frog));
        entities.Add(new Entity(16, 3.5f, 3.5f, "Myš LVL.2", 80, Entity.Type.Mouse));
        entities.Add(new Entity(20, 3.5f, 3.5f, "Pavouk LVL.2", 100, Entity.Type.Spider));
        return entities;
    }
}
