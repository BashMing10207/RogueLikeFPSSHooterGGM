using UnityEngine;

[CreateAssetMenu(fileName = "AnimHashSO", menuName = "SO/AnimHashSO")]
public class AnimHashSO : ScriptableObject
{
    public string name;
    public int hashCode { get; private set; }


    private void OnValidate()
    {
        hashCode = Animator.StringToHash(name);
        //새로고침/저장 시 업데이트됨.
    }
}
