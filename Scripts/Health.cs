using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health;
    private readonly float maxHealth = 320;
    private readonly float minHealth = 20;
    public Coroutine reduceHP;
    private void Start() 
    {
        health = 80;
        ScaleYarn();
    }
    private void Update()
    {
        ScaleYarn();
    }
    public void ChangeValue(float hp)
    {
        if (health + hp < minHealth)
        {
            if(!Collision.finish)
                transform.parent.parent.GetComponent<Settings>().GameOver();
            else
                transform.parent.parent.GetComponent<Settings>().Finish();
        }
        else if (health + hp < maxHealth)
            health += hp;
        else if (health + hp > maxHealth)
            health = maxHealth;
        
    }
    private void ScaleYarn()
    {
        var newscale = Mathf.Lerp(transform.localScale.x, health / 50, Time.deltaTime / .8f);
        transform.localScale = Vector3.one * newscale;
    }
    public IEnumerator ReduceHealthGradually(float amount)
    {
        while (true)
        {
            ChangeValue(-amount);
            yield return new WaitForSeconds(1);
        }
    }
}
