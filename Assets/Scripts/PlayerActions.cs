using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private const string ATTACK_ANIMATION_TRIGGER= "NormalAttack";
    private const string SPECIAL_ATTACK_ANIMATION_TRIGGER= "SpecialAttack";
    Animator playerAnimator;
    public int health = 4;
    public int numberOfCoins = 0;
    [SerializeField] private Transform specialAttackPoint;
    [SerializeField] private Transform specialAttackPrefab;
    [SerializeField] private Transform youLosePanel;
    [SerializeField] private AudioSource specialAttackSound;
    [SerializeField] private int specialAttackMaxAmmo = 4;
    [HideInInspector]public int specialAttackAmmo ;
    // Start is called before the first frame update
    void Awake()
    {
        youLosePanel.gameObject.SetActive(false);
        playerAnimator = GetComponent<Animator>();
        specialAttackAmmo = specialAttackMaxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnimator.SetTrigger(ATTACK_ANIMATION_TRIGGER);
        }
        if(Input.GetKeyDown(KeyCode.C) && specialAttackAmmo > 0)
        {
            playerAnimator.SetTrigger(SPECIAL_ATTACK_ANIMATION_TRIGGER);
            Instantiate(specialAttackPrefab, specialAttackPoint.position, specialAttackPoint.rotation);
            specialAttackSound.Play();
            
            specialAttackAmmo--;
        }
    }
    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
            youLosePanel.gameObject.SetActive(true);
        }
    }
}
