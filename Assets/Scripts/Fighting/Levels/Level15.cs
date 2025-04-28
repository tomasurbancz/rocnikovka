using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level15 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(200, 3.5f, 3.5f, "Žába LVL.15", 1800, Entity.Type.Frog));
        entities.Add(new Entity(205, 3.5f, 3.5f, "Pták LVL.15", 1870, Entity.Type.Bird));
        entities.Add(new Entity(210, 3.5f, 3.5f, "Myš LVL.15", 1950, Entity.Type.Mouse));
        return entities;
    }
}
