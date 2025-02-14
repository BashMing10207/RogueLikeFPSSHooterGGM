using UnityEngine;

public class Bullet : Damageable
{
    public bool isOwnerPlayer=false;

    [SerializeField]
    ProjectileSO _projectileData;
    [SerializeField]
    protected float _speed = 0.1f,_radius=0.2f,_damage=1; // 속도,총알 반지름, 피해량
    [SerializeField]
    protected float _maxTime; //최대 LifeTime (생성 후 이 시간이 지나면 총알 사라짐)
    protected float _time;
    [SerializeField]
    LayerMask _layerMask;
    protected RaycastHit _hit;

    public virtual void Init()
    {
        _time = 0; // 총알 LifeTime 초기화

    }

    public virtual void Init(float speedMulti,float radiusMulti,float damageMulti,bool isPlayer)
    {
        Init();
        isOwnerPlayer = isPlayer;
        _projectileData.speed *= speedMulti;
        _projectileData.radius *= radiusMulti;
        _projectileData.damage *= damageMulti;
    }

    public virtual void FixedUpdate()
    {
        Scan();
        Move();
    }
    protected virtual void Move()
    {
        transform.position += transform.forward * _speed*Time.fixedDeltaTime; //총알 이동(레이로 쏜 궤적에 없으면 이동)
        _time += Time.deltaTime;

        if (_time >= _maxTime)
        {
            Pool.Instance.Get(_projectileData.bulletType, gameObject); // 총알 풀링하기
        }
    }
    protected virtual void Scan()
    {
        if (Physics.SphereCast(transform.position, _radius, transform.forward, out _hit, _speed*Time.fixedDeltaTime, _layerMask, QueryTriggerInteraction.Collide))
        {
            float damageMulti = 1;
            HealthCompo healthCompo = GetHealthCompo(_hit.transform, ref damageMulti);
            if (healthCompo)
            {
                healthCompo.Damage(_damage*damageMulti);
            }

            Pool.Instance.Get(_projectileData.bulletType, gameObject); // 총알 풀링 해주기 ㅎㅎ
        }
    }
}
