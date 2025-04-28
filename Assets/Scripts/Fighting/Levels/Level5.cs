using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level5 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(49, 3.5f, 3.5f, "Myš LVL.5", 220, Entity.Type.Mouse));
        entities.Add(new Entity(55, 3.5f, 3.5f, "Pavouk LVL.5", 250, Entity.Type.Spider));
        entities.Add(new Entity(60, 3.5f, 3.5f, "Žába LVL.5", 280, Entity.Type.Frog));
        return entities;
    }
}
