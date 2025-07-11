using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public enum SkillType {none, alan, hedef};
    public static SkillType currentSkill = SkillType.none;
    public Texture2D hedefCursorTexture;
    public Texture2D alanCursorTexture;
    public Vector2 hotspot = new Vector2(64, 64);
    public GameObject meteorPrefab;
    public float fallSpeed = 10f;
    //public GameObject hedefSkillEffectPrefab; Şu an yok

    public int damage = 100;
    public float radius = 10f;

    public void ChooseSkill()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentSkill = SkillType.alan;
            Debug.Log("Alan Skilli Seçili");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentSkill = SkillType.hedef;
            Debug.Log("Target Skilli Seçili");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentSkill = SkillType.none;
            Debug.Log("Skill Bırakıldı");
        }
    }

    public void UseSkill()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitPoint = hit.point;

                if (currentSkill == SkillType.alan)
                {
                    Debug.Log("Alan Skilli Kullanıldı");
                    Instantiate(meteorPrefab, hitPoint + Vector3.up * 15f, Quaternion.identity); // Yukarıdan düşsün diye yukarı koyduk
                    currentSkill = SkillType.none;
                }
                else if (currentSkill == SkillType.hedef)
                {
                    Debug.Log("Target Skilli Kullanıldı");
                    currentSkill = SkillType.none;
                }
            }
        }
    }

     void UpdateCursor()
    {
        switch (currentSkill)
        {
            case SkillType.hedef:
                Cursor.SetCursor(hedefCursorTexture, hotspot, CursorMode.Auto);
                break;

            case SkillType.alan:
                Cursor.SetCursor(alanCursorTexture, hotspot, CursorMode.Auto);
                break;

            case SkillType.none:
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                break;
        }
    }
   
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.down * fallSpeed;
        currentSkill = SkillType.none;
        UpdateCursor();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseSkill();
        UpdateCursor();
        UseSkill();
    }
}
