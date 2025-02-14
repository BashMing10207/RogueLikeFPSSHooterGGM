using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : WeaponController,IGetCompoable,IAfterInitable
{
    public int currentWeaponIdx = 0; // 외부에서도 접근가능(임시로)

    public Animator animator;

    public WeaponCompo currentWeapon => weaponList[currentWeaponIdx];

    public override void Init(Agent agent)
    {
        _agent = agent;

        animator = GetComponent<Animator>();

        _bFireHash = Animator.StringToHash("Fire");
        _bReloadHash = Animator.StringToHash("Reload");
        _fAmmoHash = Animator.StringToHash("AmmoPerMag");// (현재총알/탄창)  -> 잔탄수 표시 애니메이션 파라미터
    }
    public override void AfterInit()
    {
        _weaponAnime = _agent.GetCompo<PlayerWeaponAnim>();
    }
    public void ChangeWeapon(int index)//무기 번호(숫자키 번호)입력
    {
        if (weaponList.Count <= index)
        {
            if (weaponList[index].isHave)
            {
                currentWeaponIdx = index;
                animator.runtimeAnimatorController = weaponList[index].animator;

                _weaponAnime.AmmoAnim();
            }
        }
    }

    public void TryUseWeapon(int fireType)
    {
        weaponList[currentWeaponIdx].Fire(fireType);
        animator.SetFloat(_fAmmoHash, (float)weaponList[currentWeaponIdx].currentAmmo / (float)weaponList[currentWeaponIdx].maxAmmo);
    }

    public void PlayEffect(int effectType)
    {
        weaponList[currentWeaponIdx].EffectInvoke(effectType);
    }

    public void Reload()
    {
        weaponList[currentWeaponIdx].Reload();
    }

    private void UpdateAmmoVisual()
    {
        _weaponAnime.AmmoAnim();
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    private void Update()
    {
        _weaponAnime.AnimationUpdate();
    }
    private void FixedUpdate()
    {
        _weaponAnime.AnimationFixedUpdate();
    }

}
