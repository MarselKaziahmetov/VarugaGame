using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelAccess : SkillButtonsBorderRecolor
{
    private int activeIndex = 0;
    private int nextIndex = 1;
    private AbilityPointsView abilityPointsView;

    private void Awake()
    {
        abilityPointsView = GameObject.FindWithTag("PointsText").GetComponent<AbilityPointsView>();
        skillTree = new List<AbilitiesSkillTree>();
        buttonComponent = new List<Button>();
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
            buttonComponent.Add(buttonObject[i].GetComponent<Button>());
            imageComponent.Add(buttonObject[i].GetComponent<Image>());
        }

        buttonComponent[0].interactable = true;
        imageComponent[0].color = defaultColor;
        for (int i = 1; i < buttonObject.Count; i++)
        {
            buttonComponent[i].interactable = false;
            imageComponent[i].color = lockedColor;
        }
    }

    public void OpenAccessToNextLevel()
    {
        //если последний уровень прокачки в ветке
        if (activeIndex == (buttonObject.Count - 1) && skillTree[activeIndex].abilityPointsCost <= PlayerLevel.instance.AbilityPoints)
        {
            buttonComponent[activeIndex].interactable = false;
            imageComponent[activeIndex].color = completedColor;

            PlayerLevel.instance.AbilityPoints -= skillTree[activeIndex].abilityPointsCost;
            abilityPointsView.UpdatePointsText();
        }
        //если не последний
        else if (activeIndex < (buttonObject.Count - 1) && skillTree[activeIndex].abilityPointsCost <= PlayerLevel.instance.AbilityPoints)
        {
            buttonComponent[activeIndex].interactable = false;
            imageComponent[activeIndex].color = completedColor;

            buttonComponent[nextIndex].interactable = true;
            imageComponent[nextIndex].color = defaultColor;

            PlayerLevel.instance.AbilityPoints -= skillTree[activeIndex].abilityPointsCost;
            abilityPointsView.UpdatePointsText();

            activeIndex++;
            nextIndex++;
        }
    }
}
