using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level10 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(125, 3.5f, 3.5f, "Bird LVL.10", 810, Entity.Type.Bird));
        entities.Add(new Entity(130, 3.5f, 3.5f, "Mouse LVL.10", 870, Entity.Type.Mouse));
        entities.Add(new Entity(135, 3.5f, 3.5f, "Spider LVL.10", 920, Entity.Type.Spider));
        return entities;
    }
}
