using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level3 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(23, 3.5f, 3.5f, "Pt�k LVL.3", 110, Entity.Type.Bird));
        entities.Add(new Entity(27, 3.5f, 3.5f, "��ba LVL.3", 130, Entity.Type.Frog));
        entities.Add(new Entity(32, 3.5f, 3.5f, "My� LVL.3", 150, Entity.Type.Mouse));
        return entities;
    }
}
