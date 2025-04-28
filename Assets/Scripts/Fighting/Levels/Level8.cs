using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level8 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(95, 3.5f, 3.5f, "Pavouk LVL.8", 540, Entity.Type.Spider));
        entities.Add(new Entity(100, 3.5f, 3.5f, "Žába LVL.8", 580, Entity.Type.Frog));
        entities.Add(new Entity(105, 3.5f, 3.5f, "Pták LVL.8", 620, Entity.Type.Bird));
        return entities;
    }
}
