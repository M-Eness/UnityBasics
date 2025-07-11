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
            if (currentSkill == SkillType.alan)
            {
                Debug.Log("Alan Skilli Kullanıldı");
                currentSkill = SkillType.none;
            }
            else if (currentSkill == SkillType.hedef)
            {
                Debug.Log("Target Skilli Kullanıldı");
                currentSkill = SkillType.none;
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
