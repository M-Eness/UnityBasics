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
    public GameObject planePrefab;
    public GameObject AreaIndıcator;
    public GameObject IndıcatorToSpawn;
    public LayerMask groundLayer;
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
            if (AreaIndıcator != null)
            {
                Destroy(AreaIndıcator);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentSkill = SkillType.none;
            Debug.Log("Skill Bırakıldı");
            if (AreaIndıcator != null)
            {
                Destroy(AreaIndıcator);
            }
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
                    Instantiate(meteorPrefab, hitPoint + Vector3.up * 15f, Quaternion.identity);
                    Destroy(AreaIndıcator);
                    currentSkill = SkillType.none;
                }
                else if (currentSkill == SkillType.hedef)
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        GameObject plane = Instantiate(planePrefab, hitPoint + Vector3.up * 15f, Quaternion.identity); // Yukarıdan düşsün diye yukarı koyduk
                        Plane planeScript = plane.GetComponent<Plane>();
                        if(planeScript != null)
                            {
                                planeScript.target = hit.transform;
                            }
                    }
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
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Zeminle çarpışma kontrolü
                if (Physics.Raycast(ray, out hit, 100f, groundLayer))
                {
                    Vector3 hitPoint = hit.point;

                    // Obje daha önce instantiate edilmemişse oluştur
                    if (AreaIndıcator == null)
                    {
                        AreaIndıcator = Instantiate(IndıcatorToSpawn, hitPoint, Quaternion.identity);
                    }

                    // Obje varsa mouse'u takip etsin
                    if (AreaIndıcator != null)
                    {
                        AreaIndıcator.SetActive(true);
                        AreaIndıcator.transform.position = hitPoint;
                    }
                }
                else
                {
                    // Zemin dışında başka bir yer ise indikatörü kaldır
                     AreaIndıcator.SetActive(false);
                }
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
