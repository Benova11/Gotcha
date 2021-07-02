using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] Slider healthSlider;

    [Tooltip("Add amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitpoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitpoints = maxHitPoints;
        healthSlider.maxValue = maxHitPoints;
        healthSlider.value = currentHitpoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        Vector3 sliderPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthSlider.transform.position = new Vector3(sliderPos.x, sliderPos.y +40 , sliderPos.z);
    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("collision");
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitpoints --;
        healthSlider.value = currentHitpoints;
        if (currentHitpoints <= 0 )
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
