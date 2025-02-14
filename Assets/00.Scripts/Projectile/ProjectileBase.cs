using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField]
    protected UnityEvent _onHit;
    [SerializeField]
    protected Vector3 _veloctiy;
    [SerializeField]
    protected ProjectileRayCommanderSO _projectileRaySO;
    [SerializeField]
    protected LayerMask _whatisTarget;
    protected Agent _agent;

    public virtual void Init(Vector3 direction,Agent agent)
    {
        _veloctiy = direction;
        _agent = agent;
    }

    protected virtual void PostRaycast()
    {
        _projectileRaySO.AddRaycastCommand(new RaycastCommand(transform.position,_veloctiy, new QueryParameters(_whatisTarget,false,QueryTriggerInteraction.Ignore,false),_veloctiy.magnitude),(ProjectileBase)this);
    }
    public virtual void AfterRaycast(RaycastHit hit)
    {
        if(hit.collider == null)
        {
            transform.position += _veloctiy;
        }
        else
        {
            _onHit?.Invoke();
        }
    }

}