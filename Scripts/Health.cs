using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static float health;
    public static float maxHealth = 200;
    public static float minHealth = 20;
    public static Coroutine reduceHP;
    private void Start() 
    {
        health = 100;
        ScaleYarn();
    }
    private void Update()
    {
        ScaleYarn();
    }
    public static void ChangeValue(float hp)
    {
        if (health + hp < minHealth)
        {
            if(!Collision.finish)
                GameManager.GameOver();
            else
                GameManager.Finish();
        }
        else if (health + hp < maxHealth)
            health += hp;
        else if (health + hp > maxHealth)
            health = maxHealth;
    }
    private void ScaleYarn()
    {
        var newscale = Mathf.Lerp(transform.localScale.x, health / 100, Time.deltaTime / .8f);
        transform.localScale = Vector3.one * newscale;
    }
    public static IEnumerator ReduceHealthGradually(float amount)
    {
        while (true)
        {
            ChangeValue(-amount);
            yield return new WaitForSeconds(.1f);
        }
    }
}