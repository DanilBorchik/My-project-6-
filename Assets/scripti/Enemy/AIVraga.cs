using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIVraga : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Nogi player;
    public float viewAngle;
    public float damage = 30;
    public float ScaleDecrease = 30;
    public float ScaleIncrease = 0.8f;
    public float MinScale = 0.5f;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private bool _popali;
    float timer = 0f;
    float timerPatryl = 0f;
    private PlayerHealthhh _playerHealthhh;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        ctobineslomalos();
    }
    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        AtackUpdate();
        Obratka();
    }
    private void AtackUpdate()
    {
     if (!_popali)
        {
            if (_isPlayerNoticed)
            {
                if (Vector3.Distance(transform.position, _playerHealthhh.transform.position) <2)
                {
                    _playerHealthhh.DealDamage(damage * Time.deltaTime);
                }
            }
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealthhh = player.GetComponent<PlayerHealthhh>();
    }
    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
        PatrolUpdate();
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            timerPatryl += Time.deltaTime;
           if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) 
            {
                if(timerPatryl > 8f)
                {
                    PickNewPatrolPoint();
                    timerPatryl = 0f;
                }
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    public void Ymenshil()
    {
        transform.localScale = Vector3.one * 0.4f ;
        _popali = true;
    }
     void ctobineslomalos()
    {
        _popali = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        var PlayerHealth = collision.gameObject.GetComponent<PlayerHealthhh>();
        if (PlayerHealth != null)
        {
            if (_popali)
            {
                GetComponent<EnemyHealth>().DealDamage(1000);
            }
            
        }
    }
    void Obratka()
    {
        if (_popali)
        {
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                transform.localScale = Vector3.one;
                timer = 0f;
                _popali = false;
            }
        }
    }
}
