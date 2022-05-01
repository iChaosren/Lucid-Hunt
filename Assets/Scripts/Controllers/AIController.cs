using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private IMovementManager movementManager { get; set; }
    private IAIStateManager aiStateManager { get; set; }
    private IProjectileManager projectileManager { get; set; }


    [InlineEditor] public MovementSettings movementSettings = null;
    [InlineEditor] public ProjectileSettings projectileSettings = null;
    [InlineEditor] public AISettings aiSettings = null;

    void Awake()
    {
        movementManager = new MovementManager(transform, movementSettings);
        projectileManager = new ProjectileManager(transform, projectileSettings, Instantiate);
        aiStateManager = new AIStateManager(transform, aiSettings, movementManager, projectileManager);
    }

    void Update()
    {
        aiStateManager.UpdateState();
    }

#if(UNITY_EDITOR)
    void OnDrawGizmos()
    {
        if (aiStateManager == null)
            return;

        Handles.color = Color.blue;
        Handles.Label(transform.position, aiStateManager.currentState.ToString(), new GUIStyle() { fontSize = 32 }); //System.Enum.GetName(typeof(BrainState), aiStateManager.currentState.ToString()));
    }
#endif
}