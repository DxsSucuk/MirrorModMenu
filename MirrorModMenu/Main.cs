using System;
using System.Reflection;
using UnityEngine;
using UnityModManagerNet;

namespace MirrorModMenu
{
    public class Main
    {
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.Logger.Log("Injected Mod Menu.");
            modEntry.OnGUI = OnGUI;
            return true;
        }
        static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            GUILayout.Label("Cheat Menu");

            if (GUILayout.Button("Give 1k"))
            {
                GameTool.roleData.Money += 1000;
                GameTool.Save();
            }
            
            if (GUILayout.Button("Heal 1k"))
            {
                try
                {
                    StarBox.Instance.Player.CurHP += 1000;
                }
                catch (Exception ex)
                {
                    modEntry.Logger.LogException(ex);
                }
            }
            
            if (GUILayout.Button("Try to kill enemy"))
            {
                try
                {
                    StarBox.Instance.Enemy.CurHP = 1;
                }
                catch (Exception ex)
                {
                    modEntry.Logger.LogException(ex);
                }
            }
            
            if (GUILayout.Button("Reset turns"))
            {
                try
                {
                    var t = StarBox.Instance;
                    var prop = t.GetType().GetField("<Turn>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (prop == null)
                    {
                        modEntry.Logger.Log("ERROR - Turn variable was not found!");
                        return;
                    }
                    prop.SetValue(t, 0);
                }
                catch (Exception exception)
                {
                    modEntry.Logger.LogException(exception);
                }
            }

            if (GUILayout.Button("Unlock all Achievements"))
            {
                GameTool.SetAchievement("skill_10");
                GameTool.SetAchievement("skill_15");
                GameTool.SetAchievement("prop_6");
                GameTool.SetAchievement("prop_11");
                GameTool.SetAchievement("slot_2");
                GameTool.SetAchievement("slot_4");
                GameTool.SetAchievement("hp_2");
                GameTool.SetAchievement("hp_4");
                GameTool.SetAchievement("phy_2");
                GameTool.SetAchievement("phy_4");
                GameTool.SetAchievement("magic_2");
                GameTool.SetAchievement("magic_4");
                GameTool.SetAchievement("cure_2");
                GameTool.SetAchievement("cure_4");
                GameTool.SetAchievement("rage_2");
                GameTool.SetAchievement("rage_4");
                
                foreach (BaseData baseData in GameTool.roleData.dataList)
                {
                    GameTool.SetAchievement("jieju_" + baseData.id + "_1");
                    GameTool.SetAchievement("wancheng_" + baseData.id + "_2");
                }
                
                modEntry.Logger.Log("Finished adding Achievements! :>");
                
            }
        }
    }
}