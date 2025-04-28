using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level7 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(80, 3.5f, 3.5f, "Frog LVL.7", 420, Entity.Type.Frog));
        entities.Add(new Entity(85, 3.5f, 3.5f, "Bird LVL.7", 460, Entity.Type.Bird));
        entities.Add(new Entity(90, 3.5f, 3.5f, "Mouse LVL.7", 500, Entity.Type.Mouse));
        return entities;
    }
}
