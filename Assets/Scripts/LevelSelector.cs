using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelIcon;
    public GameObject canvas;
    public int numberOfLevels = 50;
    public Vector2 iconSpacing;
    private Rect panelDimensions;
    private Rect iconDimensions;
    private int amountPerPage;
    private int currentLevelCount;

    // Start is called before the first frame update
    void Start()
    {
        //calulate how many btn can fit in a page / total level = panel to create

        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
        //how many btn can fit in a row
        int maxInARow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int maxInACol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        amountPerPage = maxInARow * maxInACol;
        int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        LoadPanels(totalPages);
    }
    void LoadPanels(int numberOfPanels)
    {
        GameObject panelClone = Instantiate(levelHolder) as GameObject;

        for (int i = 1; i <= numberOfPanels; i++)
        {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(canvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Page-" + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
            SetUpGrid(panel);
            int numberOfIcons = i == numberOfPanels ? numberOfLevels - currentLevelCount : amountPerPage;
            LoadIcons(numberOfIcons, panel);
        }
        Destroy(panelClone);
    }
    void SetUpGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = iconSpacing;
    }
    void LoadIcons(int numberOfIcons, GameObject parentObject)
    {
        for (int i = 1; i <= numberOfIcons; i++)
        {
            currentLevelCount++;
            GameObject icon = Instantiate(levelIcon) as GameObject;
            icon.transform.SetParent(canvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = i.ToString();
            icon.GetComponentInChildren<TextMeshProUGUI>().SetText(currentLevelCount.ToString());
        }
    }

    // Update is called once per frame
    void Update()           
    {

    }
}