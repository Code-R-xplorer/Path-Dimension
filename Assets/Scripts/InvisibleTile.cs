using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTile : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool hidden = true;
    [SerializeField] private float tileShowTime = 5;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        GameManager.Instance.onToggleTiles += ShowTile;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator.Play("FadeOut",1,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowTile()
    {
        if (hidden)
        {
            _animator.Play("FadeIn", 1, 0f);
            StartCoroutine(TileCooldown(tileShowTime));
        }
    }

    private IEnumerator TileCooldown(float wait)
    {
        hidden = false;
        yield return new WaitForSeconds(wait);
        _animator.Play("FadeOut",1,0f);
        hidden = true;



    }
}
