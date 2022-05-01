using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : IAIStateManager
{
    public Transform aiTransform { get; private set; }
    private BrainState _currentState;
    public BrainState currentState
    {
        get => _currentState;
        private set
        {
            _currentState = value;
            deltaStateChange = 0f;
            if (value == BrainState.Attacking)
                AttackTowardPlayer = Random.Range(0, 2) == 1;
        }
    }
    public AISettings aiSettings { get; private set; }
    public IMovementManager movementManager { get; private set; }
    public IProjectileManager projectileManager { get; private set; }

    public AIStateManager(Transform aiTransform, AISettings aiSettings, IMovementManager movementManager, IProjectileManager projectileManager)
    {
        this.aiTransform = aiTransform;
        this.currentState = currentState;
        this.aiSettings = aiSettings;
        this.movementManager = movementManager;
        this.projectileManager = projectileManager;
    }

    private float deltaStateChange = 0.0f;

    private bool PlayerDotProductUpdatedThisFrame = false;
    private float PlayerDotProduct
    {
        get
        {
            if (!PlayerDotProductUpdatedThisFrame)
            {
                _playerDotProduct = Vector3.Dot(PlayerDirection, aiTransform.forward);
                PlayerDotProductUpdatedThisFrame = true;
            }

            return _playerDotProduct;
        }
    }
    private float _playerDotProduct = 0.0f;

    private bool PlayerDirectionUpdatedThisFrame = false;
    private Vector3 PlayerDirection
    {
        get
        {
            if (!PlayerDirectionUpdatedThisFrame)
            {
                _playerDirection = (aiTransform.position - PlayerGlobal.Instance.PlayerTransform.position).normalized;
                PlayerDirectionUpdatedThisFrame = true;
            }

            return _playerDirection;
        }
    }
    private Vector3 _playerDirection = Vector3.zero;

    private bool PlayerDistanceUpdatedThisFrame = false;
    private float PlayerDistance
    {
        get
        {
            if (!PlayerDistanceUpdatedThisFrame)
            {
                _playerDistance = Vector3.Distance(aiTransform.position, PlayerGlobal.Instance.PlayerTransform.position);
                PlayerDistanceUpdatedThisFrame = true;
            }

            return _playerDistance;
        }
    }
    private float _playerDistance = 0.0f;

    private bool AngleToPlayerUpdatedThisFrame = false;
    private float AngleToPlayer
    {
        get
        {
            if (!AngleToPlayerUpdatedThisFrame)
            {
                _angleToPlayer = Vector2.SignedAngle(-aiTransform.up, PlayerDirection);
                AngleToPlayerUpdatedThisFrame = true;
            }

            return _angleToPlayer;
        }
    }
    private float _angleToPlayer = 0.0f;

    private float CurrentStateDuration
    {
        get
        {
            switch (currentState)
            {
                case BrainState.Fleeing:
                    return aiSettings.fleeingDuration;
                case BrainState.MoveIn:
                    return aiSettings.moveInDuration;
                case BrainState.Attacking:
                    return aiSettings.attackingDuration;
                case BrainState.Idle:
                default:
                    return aiSettings.idleDuration;
            }
        }
    }

    private bool AttackTowardPlayer = false;

    private bool ShouldAttack()
    {

        return false;
    }

    private bool CanFireProjectile()
    {

        return false;
    }

    private void MoveTowardsPlayer()
    {
        if (AngleToPlayer >= -10f && AngleToPlayer <= 10f)
            movementManager.MoveInDirection(new Vector2(0, 1));
        else if (AngleToPlayer < -10f)
            movementManager.MoveInDirection(new Vector2(1, 1));
        else
            movementManager.MoveInDirection(new Vector2(-1, 1));
    }

    private void MoveAwayFromPlayer()
    {
        if (AngleToPlayer >= 170f && AngleToPlayer <= -170f)
            movementManager.MoveInDirection(new Vector2(0, 1));
        else if (AngleToPlayer >= 0f)
            movementManager.MoveInDirection(new Vector2(1, 1));
        else
            movementManager.MoveInDirection(new Vector2(-1, 1));
    }

    public void UpdateState()
    {
        PlayerDistanceUpdatedThisFrame = false;
        PlayerDirectionUpdatedThisFrame = false;
        PlayerDotProductUpdatedThisFrame = false;
        AngleToPlayerUpdatedThisFrame = false;

        if (deltaStateChange < CurrentStateDuration)
        {
            deltaStateChange += Time.deltaTime;
        }
        else
        {
            switch (currentState)
            {
                case BrainState.Idle:
                    if (PlayerDistance < aiSettings.minimumDistanceFromPlayer)
                        currentState = BrainState.Fleeing;
                    else if (PlayerDistance > aiSettings.maximumDistanceFromPlayer)
                        currentState = BrainState.MoveIn;
                    else
                        currentState = BrainState.Attacking;
                    break;
                case BrainState.Fleeing:
                    if (PlayerDistance > aiSettings.minimumDistanceFromPlayer)
                        currentState = BrainState.Attacking;
                    break;
                case BrainState.MoveIn:
                    if (PlayerDistance < aiSettings.maximumDistanceFromPlayer)
                        currentState = BrainState.Attacking;
                    break;
                case BrainState.Attacking:
                    if (PlayerDistance < aiSettings.minimumDistanceFromPlayer)
                        currentState = BrainState.Fleeing;
                    else if (PlayerDistance > aiSettings.maximumDistanceFromPlayer)
                        currentState = BrainState.MoveIn;
                    else
                        currentState = BrainState.Idle;
                    break;
            }
            deltaStateChange += Time.deltaTime;
        }

        RunAIFrame();
    }



    public void RunAIFrame()
    {
        //Negative -> Player is to the Right
        //Positive -> Player is to the Left

        switch (currentState)
        {
            case BrainState.Idle:
                movementManager.MoveInDirection(new Vector2(0, 1));
                break;
            case BrainState.Fleeing:
                MoveAwayFromPlayer();
                break;
            case BrainState.MoveIn:
                MoveTowardsPlayer();
                break;
            case BrainState.Attacking:
                if (AttackTowardPlayer)
                {
                    MoveTowardsPlayer();
                    //Shoot Projectile Ahead
                    //projectileManager.FireProjectile();
                }
                else
                {
                    MoveAwayFromPlayer();
                    //Drop Projectile Behind
                    //projectileManager.FireProjectile();
                }
                break;
        }
    }
}
