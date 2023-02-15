using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;

    [Header ("SFX")]
    [SerializeField] private AudioClip arrowSound;
    
    private float cooldownTimer;
    // Start is called before the first frame update

    private void Attack(){
        cooldownTimer = 0;
        SoundManager.instance.PlaySound(arrowSound);
        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindArrow(){
        for(int i = 0; i < arrows.Length; ++i){
            if(!arrows[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }

    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= attackCooldown){
            Attack();
        }
    }
}
