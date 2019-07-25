using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;

public class Boot : MonoBehaviour
{

    [SerializeField]
    public RenderMesh entityMesh;

    void Start()
    {
        var entityManager = World.Active.EntityManager;
        EntityArchetype a = entityManager.CreateArchetype(typeof(RenderMesh), typeof(Translation), typeof(LocalToWorld), typeof(Race), typeof(Scale));
        Entity en = entityManager.CreateEntity(a);
        entityManager.SetSharedComponentData<RenderMesh>(en, entityMesh);
        entityManager.SetComponentData<Translation>(en, new Translation{});
        entityManager.SetComponentData<Race>(en, new Race{ health = 100, energy = 100, speed = 1});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
