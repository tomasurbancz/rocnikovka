using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level19 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(260, 3.5f, 3.5f, "Žába LVL.19", 2740, Entity.Type.Frog));
        entities.Add(new Entity(265, 3.5f, 3.5f, "Pták LVL.19", 2820, Entity.Type.Bird));
        entities.Add(new Entity(270, 3.5f, 3.5f, "Myš LVL.19", 2900, Entity.Type.Mouse));
        return entities;
    }
}
