using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChaseFX : MonoBehaviour
{
    public Transform player;
    public GameObject character;
    private PosterizeEffect effect;
    private BadTVEffect badTVEffect;
    private float distort;
    private int level;

    private void Start()
    {
        effect = character.GetComponent<PosterizeEffect>();
        badTVEffect = character.GetComponent<BadTVEffect>();
        distort = badTVEffect.fineDistort;
        level = effect.level;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 18.5f)
        {
            badTVEffect.fineDistort = 8.9f;
            effect.level = 20;
        }
        else
        {
            badTVEffect.fineDistort = distort;
            effect.level = level;
        }
        
    }
}
