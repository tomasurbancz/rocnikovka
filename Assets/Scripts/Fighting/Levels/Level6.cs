using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Level6 : FightLevel
{
    public override List<Entity> GetEntities()
    {
        List<Entity> entities = new List<Entity>();
        entities.Add(new Entity(65, 3.5f, 3.5f, "Pták LVL.6", 310, Entity.Type.Bird));
        entities.Add(new Entity(70, 3.5f, 3.5f, "Myš LVL.6", 340, Entity.Type.Mouse));
        entities.Add(new Entity(76, 3.5f, 3.5f, "Pavouk LVL.6", 380, Entity.Type.Spider));
        return entities;
    }
}
