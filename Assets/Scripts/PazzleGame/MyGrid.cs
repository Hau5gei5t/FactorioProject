using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid 
{
    
    private bool ischanged = true;
    private int width;
    private int height;
    private float sellSize;
    private Vector3 originPosition;
    public static int[,] gridArray;
    private TextMesh[,] debugTextArray;
    public MyGrid(int width, int height, float sellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.sellSize = sellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];

        debugTextArray = new TextMesh[width, height];
        
            for (int x = 0; x < gridArray.GetLength(0); x++)
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    debugTextArray[x, y] = CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(sellSize, sellSize) * .5f, 20,
                        new Color(0,0,0,0), TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        
    }

    public static TextMesh CreateWorldText( string text, Transform parent=null, Vector3 localPosition = default(Vector3), int fontSize = 40,
        Color? color = null, TextAnchor textAnchor=TextAnchor.UpperLeft, TextAlignment textAlignment= TextAlignment.Left, int sortingOrder = 5000)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    public static TextMesh CreateWorldText(Transform parent,string text, Vector3 localPosition, int fontSize, 
        Color color, TextAnchor textAnchor,TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;

    }

    public Vector3 GetWorldPosition(int x,int y)
    {
        return new Vector3(x, y) * sellSize + originPosition;
    }
    public int[,] GetArray()
    {
        return gridArray;
    }

    public void GetXY(Vector3 worldPosition,out int x,out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / sellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / sellSize);
    }
    
    public void SetValue(int x, int y, int value)
    {
        if(x>=0 && y>=0 && x<width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition,int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        if (gridArray[x, y] == 0 || value == 0)
        {
            SetValue(x, y, value);
            ischanged = true;
        }
        else
        {
            ischanged = false;
        }
    }
    public bool IsChanged()
    {

        return ischanged;
    }
}
