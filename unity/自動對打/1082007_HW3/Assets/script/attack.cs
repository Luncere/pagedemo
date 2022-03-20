using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    
    public Animator A_p;
    public Animator A_c;
    public Text text_c;
    public Text text_p;
    public Text show_end;
    public RectTransform HealthBar_P;
    public RectTransform HealthBar_C;
    public GameObject start;
    public GameObject restart;
    private int HP_P;
    private int HP_C;
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void  Restart()
    {
        HP_P = 100;
        HP_C = 100;
        HealthBar_P.sizeDelta = new Vector2(100, HealthBar_P.sizeDelta.y);
        HealthBar_C.sizeDelta = new Vector2(100, HealthBar_C.sizeDelta.y);
        text_c.text = "HP:" + HP_C + "/100";
        text_p.text = "HP:" + HP_P + "/100";
        restart.SetActive(false);
        start.SetActive(true);
        show_end.text = "";
    }
    public void click_bt()
    {
        StartCoroutine(autoattack());
    }
    IEnumerator autoattack()
    {
        start.SetActive(false);
        while (true)
        {
            HP_P -= Random.Range(0, 20);
            if (HP_P > 0)
            {
                A_p.SetTrigger("Take Damage");
                HealthBar_P.sizeDelta = new Vector2(HP_P, HealthBar_P.sizeDelta.y);
                text_p.text = "HP:" + HP_P + "/100";
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                restart.SetActive(true);
                show_end.text = "Computer is the winner and you are the loser";
                HP_P = 0;
                A_p.SetTrigger("Die");
                HealthBar_P.sizeDelta = new Vector2(HP_P, HealthBar_P.sizeDelta.y);
                text_p.text = "HP:" + HP_P + "/100";
                break;
            }
            HP_C -= Random.Range(0, 20);
            if (HP_C > 0)
            {
                A_c.SetTrigger("Take Damage");               
                HealthBar_C.sizeDelta = new Vector2(HP_C, HealthBar_C.sizeDelta.y);
                text_c.text = "HP:" + HP_C + "/100";
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                restart.SetActive(true);
                show_end.text = "You are the winner and computer is the loser";
                HP_C = 0;
                A_c.SetTrigger("Die");
                HealthBar_C.sizeDelta = new Vector2(HP_C, HealthBar_C.sizeDelta.y);
                text_c.text = "HP:" + HP_C + "/100";
                break;
            }
        }
    }
}
