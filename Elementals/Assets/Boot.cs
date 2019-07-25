using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using System;
using System.Collections.Generic;

public class Boot : MonoBehaviour
{

    [SerializeField]
    public RenderMesh entityMesh;

    void Start()
    {
        var entityManager = World.Active.EntityManager;
        EntityArchetype a = entityManager.CreateArchetype(typeof(RenderMesh), typeof(Translation), typeof(LocalToWorld), typeof(Race), typeof(Scale),
        typeof(Skill));
        Entity en = entityManager.CreateEntity(a);
        entityManager.SetSharedComponentData<RenderMesh>(en, entityMesh);
        entityManager.SetComponentData<Translation>(en, new Translation{});
        entityManager.SetComponentData<Race>(en, Data.Singleton.selectedRace);
        entityManager.SetComponentData<Scale>(en, new Scale{Value = Data.Singleton.selectedRace.size});
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
