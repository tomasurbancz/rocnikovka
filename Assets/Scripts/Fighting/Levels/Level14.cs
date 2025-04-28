using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level14 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(185, 3.5f, 3.5f, "Pták LVL.14", 1580, Entity.Type.Bird));
        entities.Add(new Entity(190, 3.5f, 3.5f, "Myš LVL.14", 1650, Entity.Type.Mouse));
        entities.Add(new Entity(195, 3.5f, 3.5f, "Pavouk LVL.14", 1720, Entity.Type.Spider));
        return entities;
    }
}
