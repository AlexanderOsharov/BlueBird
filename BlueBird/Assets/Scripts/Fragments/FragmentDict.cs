using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentDict : MonoBehaviour {
    [SerializeField] List<FragmentType> FragmentTypes;
    [SerializeField] List<string> FragmentInfo;
    [SerializeField] List<Button> FragmentImage;

    public int GetIndex(FragmentType type) {
        for (int i = 0; i < FragmentTypes.Count; i++) {
            if (FragmentTypes[i] == type) {
                return i;
            }
        }
        return 0;
    }

    public string GetInfo(FragmentType type) {
        return FragmentInfo[GetIndex(type)];
    }

    public Button GetButton(FragmentType type) {
        return FragmentImage[GetIndex(type)]; 
    }
}
