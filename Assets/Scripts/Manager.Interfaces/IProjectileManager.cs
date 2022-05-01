using UnityEngine;

public interface IProjectileManager : IRequiresInstantiate
{
    Transform emitFrom { get; }
    ProjectileSettings projectile { get; }

    void FireProjectile();
    void ChangeProjectile(ProjectileSettings newProjectile);
}