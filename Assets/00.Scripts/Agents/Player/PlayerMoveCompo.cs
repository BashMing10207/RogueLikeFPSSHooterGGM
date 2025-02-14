using UnityEngine;
public class PlayerMoveCompo : MoveCompo,IGetCompoable
{
    public Transform cameraRoot;

    public bool isSliding;

    [SerializeField]
    float _maxSpeed = 10, _accelation = 25, _jumpPower = 5, _damp=3,_gravity = -11,_plHeight=2,_plRaius=0.26f; //PlayerState�� �� ������
    [SerializeField]
    float _mouseSpeed = 5f;//PlayerSettingMing ���� ���ߵ�


    public bool _isCanJump, _isGround;

    [SerializeField]
    private LayerMask _whatIsGround;

    private Vector2 _mouseSum;
    private Vector3 _movDir;

    private RaycastHit _groundCheck;

    Collider[] _groundCheckCols = new Collider[1];

    void Start()
    {
        Player.Instance.jumpInputAction += Jump;
    }

    // Update is called once per frame
    private void Update()
    {
        RotateCamera();
    }
    void FixedUpdate()
    {
        _isCanJump = false;
        _isGround = false;

        Vector3 input = BashUtils.V2toV3(Player.Instance.playerInput.movement);
        //_movDir = BashUtils.V3X0Z(cameraRoot.TransformVector(input)).normalized;
        input = (Quaternion.Euler(0, _mouseSum.x, 0) * input);

        //���� ��� ���� ������ �����ϱ� ���� ��� ����(Overlap)�� ������ ���� ����(SphereCast)�� ��������.
        if (Physics.OverlapSphereNonAlloc(transform.position-Vector3.up*_plHeight/2,_plRaius+0.1f,_groundCheckCols,_whatIsGround) > 0) //������ üũ(�γ��� ����)
        {
            _isCanJump = true;

            if (Physics.SphereCast(transform.position, _plRaius, -transform.up, out _groundCheck, _plHeight / 2, _whatIsGround))//������ üũ(������ ����)
            {
                _isGround = true;

                //OnGorund(
                //����O ����O
                MoveOnGorund(ref input);
            }
            else
            {
                //OnAirAndGround?
                //����x ����O
                
            }

        }
        else
        {
            //OnAir
            //����X ����X

        }

    //    _movDir = input * (Mathf.Lerp(1, 0, (Vector3.Project(input, rigidbody.velocity) + rigidbody.velocity).magnitude / _maxSpeed)
    //+ Vector3.Project(input, -rigidbody.velocity.normalized).magnitude);
        _movDir = input * Mathf.Lerp(1, 0, (Vector3.Project(input, rigidCompo.linearVelocity)+rigidCompo.linearVelocity).magnitude / _maxSpeed);

        
        //_movDir += Vector3.Project(input, Quaternion.Euler(0, 90, 0) * rigidbody.velocity.normalized);
        //_movDir += Vector3.Project(input, Quaternion.Euler(0, 270, 0) * rigidbody.velocity.normalized);

        //rigidCompo.linearVelocity += _movDir;
        rigidCompo.AddForce(_movDir,ForceMode.Impulse);

    }

    private void Jump()
    {
        if(_isCanJump) 
        rigidCompo.AddForce(transform.up*_jumpPower,ForceMode.Impulse);
    }

    private void MoveOnGorund(ref Vector3 input)
    {
        Vector3 horizontalSpeed = BashUtils.V3X0Z(rigidCompo.linearVelocity);
        //rigidCompo.linearVelocity = Vector3.up * rigidCompo.linearVelocity.y
        //   + Vector3.Lerp(horizontalSpeed, Vector3.zero, _damp * Time.fixedDeltaTime);
        //����

        input = Vector3.ProjectOnPlane(input,_groundCheck.normal);
        //�������� ��� ���� �� �ְ��ϴ� �ڵ�;
    }

    private void MoveOnAir()
    {

    }

    private void RotateCamera()
    {
        //_mouseTmp += RPlayerMana.Instance.playerInput.mouseMov*_mouseSpeed;
        _mouseSum.x += Input.GetAxisRaw("Mouse X") * _mouseSpeed * Time.deltaTime;
        _mouseSum.y -= Input.GetAxisRaw("Mouse Y")  *_mouseSpeed*Time.deltaTime;
        _mouseSum.y = Mathf.Clamp(_mouseSum.y, -89, 89);

        cameraRoot.rotation = Quaternion.Euler(_mouseSum.y, _mouseSum.x, 0);
    }
}
