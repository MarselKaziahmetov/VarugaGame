using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonsBorderRecolor : MonoBehaviour
{
    public enum TreesType
    {
        ShootngType,
        PassiveType,
        DashType
    }

    [Header("Type Of Ability Tree")]
    [SerializeField] public TreesType treesType;

    [Header("Sources On Objects")]
    [SerializeField] public List<GameObject> buttonObject; 
    [SerializeField] private List<Image> borders;

    [Header("Colors For Button States")]
    [SerializeField] public Color lockedColor;
    [SerializeField] public Color defaultColor;
    [SerializeField] public Color completedColor;

    [Header("Colors For Border States")]
    [SerializeField] private Color unavialableColor;
    [SerializeField] private Color avialableColor;
    [SerializeField] private Color fulledColor;
    
    [HideInInspector] public List<AbilitiesSkillTree> skillTree;
    [HideInInspector] public List<Button> buttonComponent;
    [HideInInspector] public List<Image> imageComponent;

    private void Start()
    {
        skillTree = new List<AbilitiesSkillTree>();
        imageComponent = new List<Image>();

        for (int i = 0; i < buttonObject.Count; i++)
        {
            switch (treesType)
            {
                case TreesType.ShootngType:
                    skillTree.Add(buttonObject[i].GetComponent<SpawnerAbilitySkillTree>());
                    break;
                case TreesType.PassiveType:
                    skillTree.Add(buttonObject[i].GetComponent<PassiveAbilitySkillTree>());
                    break;
                case TreesType.DashType:
                    skillTree.Add(buttonObject[i].GetComponent<DashAbilitySkillTree>());
                    break;
                default:
                    break;
            }
            imageComponent.Add(buttonObject[i].GetComponent<Image>());
        }

        UpdateBordersColor();
    }

    public void UpdateBordersColor()
    {
        //Debug.Log(borders.Count);
        
        for (int i = 0; i < borders.Count; i++)
        {
            //Debug.Log("i"+i);

            if (imageComponent[i].color == lockedColor || skillTree[i].abilityPointsCost > PlayerLevel.instance.AbilityPoints)
            {
                borders[i].color = unavialableColor;
            }
            if (imageComponent[i].color == defaultColor && skillTree[i].abilityPointsCost <= PlayerLevel.instance.AbilityPoints)
            {
                borders[i].color = avialableColor;
            }
            if (imageComponent[i].color == completedColor)
            {
                borders[i].color = fulledColor;
            }
        }
        //Debug.Log("//////////////////");
    }
}
