using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level12 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(155, 3.5f, 3.5f, "Spider LVL.12", 1160, Entity.Type.Spider));
        entities.Add(new Entity(160, 3.5f, 3.5f, "Frog LVL.12", 1230, Entity.Type.Frog));
        entities.Add(new Entity(165, 3.5f, 3.5f, "Bird LVL.12", 1300, Entity.Type.Bird));
        return entities;
    }
}
