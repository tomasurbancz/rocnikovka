using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level11 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(140, 3.5f, 3.5f, "Frog LVL.11", 980, Entity.Type.Frog));
        entities.Add(new Entity(145, 3.5f, 3.5f, "Bird LVL.11", 1040, Entity.Type.Bird));
        entities.Add(new Entity(150, 3.5f, 3.5f, "Mouse LVL.11", 1100, Entity.Type.Mouse));
        return entities;
    }
}
