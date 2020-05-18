using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleLayoutGroup : LayoutGroup
{
    public enum FitType
    {
        Uniform,
        Width, 
        Height,
        FixedRows,
        FixedColumns
    }

    public FitType fitType;

    [Range(0, 20)]
    public int rows;
    [Range(0, 20)]
    public int collums;
    public Vector2 cellSize;
    public Vector2 spacing;

    public bool fitX;
    public bool fitY;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        if (fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform)
        {
            fitX = true;
            fitY = true;

            float sqrRt = Mathf.Sqrt(transform.childCount);
            rows = Mathf.CeilToInt(sqrRt);
            collums = Mathf.CeilToInt(sqrRt);
        }

        if(fitType == FitType.Width || fitType == FitType.FixedColumns)
        {
            rows = Mathf.CeilToInt(transform.childCount / (float)collums);
        }
        if(fitType == FitType.Height || fitType == FitType.FixedRows)
        {
            collums = Mathf.CeilToInt(transform.childCount / (float)rows);
        }

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = (parentWidth / (float)collums) - ((spacing.x / (float)collums) * (collums -1)) - (padding.left / (float)collums) - (padding.right / (float)collums);
        float cellHeight = (parentHeight / (float)rows) - ((spacing.y / (float)rows) * (rows - 1)) - (padding.top / (float) rows) - (padding.bottom / (float) rows);

        cellSize.x = fitX ? cellWidth : cellSize.x;
        cellSize.y = fitY ? cellHeight : cellSize.y;

        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / collums;
            columnCount = i % collums;

            var item = rectChildren[i];

            var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount)+ padding.left;
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }
    }

    public override void CalculateLayoutInputVertical()
    {
    }

    public override void SetLayoutHorizontal()
    {
    }

    public override void SetLayoutVertical()
    {
    }
}
