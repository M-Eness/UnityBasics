using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BloodManager : MonoBehaviour
{
    public static BloodManager KanSayacı;
    public int currentBlood = 0;
    public TMP_Text bloodText;

    private void Awake()
    {
        KanSayacı = this;
    }

    public void addBlood(int Amount)
    {
        currentBlood += Amount;
        UpdateBloodUI();
    }

    public void UpdateBloodUI()
    {
        bloodText.text = currentBlood.ToString();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateBloodUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
