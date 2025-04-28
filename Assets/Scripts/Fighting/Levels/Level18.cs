using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level18 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(245, 3.5f, 3.5f, "Pták LVL.18", 2500, Entity.Type.Bird));
        entities.Add(new Entity(250, 3.5f, 3.5f, "Myš LVL.18", 2580, Entity.Type.Mouse));
        entities.Add(new Entity(255, 3.5f, 3.5f, "Pavouk LVL.18", 2660, Entity.Type.Spider));
        return entities;
    }
}
