using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : IProjectileManager
{
    public ProjectileManager(Transform emitFrom, ProjectileSettings projectile, GameObjectDelegates.InstantiationFunction instantiationFunction)
    {
        this.emitFrom = emitFrom;
    }

    public Transform emitFrom { get; private set; }
    public ProjectileSettings projectile { get; private set; }
    public GameObjectDelegates.InstantiationFunction Instantiate { get; private set; }

    public void FireProjectile()
    {
        Instantiate(projectile.prefab, emitFrom.position, emitFrom.rotation);
    }

    public void ChangeProjectile(ProjectileSettings newProjectile)
    {
        projectile = newProjectile;
    }

}
