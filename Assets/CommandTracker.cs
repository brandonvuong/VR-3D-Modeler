using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUndoableAction
{
    void Do();
    void Undo();
    void Redo();
}

public class CommandTracker : MonoBehaviour
{
    public bool undo;

    public bool redo; 

    private Stack<IUndoableAction> undoStack = new Stack<IUndoableAction>();
    private Stack<IUndoableAction> redoStack = new Stack<IUndoableAction>();

/*    static CommandTracker instance;
    static int counter = 0; 
    List<Tuple<GameObject, Transform>> objectList;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void enqueue(GameObject GO, Transform T)
    {
        objectList.Add(Tuple.Create(GO, T));
        counter++; 
    }*/
    public void PerformAction(IUndoableAction action)
    {
        action.Do();
        undoStack.Push(action);
        redoStack.Clear();
    }
    public void Undo()
    {
        if(undoStack.Count > 0)
        {
            IUndoableAction action = undoStack.Pop();
            action.Undo();
            redoStack.Push(action);
        }
    }
    public void Redo()
    {
        if(redoStack.Count > 0)
        {
            IUndoableAction action = redoStack.Pop();
            action.Redo();
            undoStack.Push(action);
        }
    }
/*    void Update()
    {

    }*/
}

/*public class MoveObjectAction : IUndoableAction
{
    private Transform transform;
    private Vector3 oldPos; 
    private Vector3 newPos;
    public MoveObjectAction(Transform transform, Vector3 oldPos, Vector3 newPos)
    {
        this.transform = transform;
        this.oldPos = oldPos;
        this.newPos = newPos;
    }
    public void Do()
    {
        transform.position = newPos;
    }
    public void Undo()
    {
        transform.position = oldPos; 
    }
    public void Redo()
    {
        Do();
    }
}*/
public class ScaleObjectAction : IUndoableAction
{
    private Transform transform;
    private Vector3 oldScale;
    private Vector3 newScale;

    public ScaleObjectAction(Transform transform, Vector3 oldScale, Vector3 newScale)
    {
        this.transform = transform;
        this.oldScale = oldScale;
        this.newScale = newScale;
    }

    public void Do()
    {
        transform.localScale = newScale;
    }

    public void Undo()
    {
        transform.localScale = oldScale;
    }

    public void Redo()
    {
        Do();
    }
}
public class RotateObjectAction : IUndoableAction
{
    private Transform transform;
    private Quaternion oldRotation;
    private Quaternion newRotation;

    public RotateObjectAction(Transform transform, Quaternion oldRotation, Quaternion newRotation)
    {
        this.transform = transform;
        this.oldRotation = oldRotation;
        this.newRotation = newRotation;
    }

    public void Do()
    {
        transform.localRotation = newRotation;
    }

    public void Undo()
    {
        transform.localRotation = oldRotation;
    }

    public void Redo()
    {
        Do();
    }
}
public class ColorSwapAction : IUndoableAction
{
    private GameObject objectToColorSwap;
    private Color oldColor;
    private Color newColor; 

    public ColorSwapAction(GameObject objectToColorSwap, Color oldColor, Color newColor)
    {
        this.objectToColorSwap = objectToColorSwap;
        this.oldColor = oldColor;
        this.newColor = newColor;
    }
    public void Do()
    {
        objectToColorSwap.GetComponent<Renderer>().material.color = newColor;
    }
    public void Undo()
    {
        objectToColorSwap.GetComponent<Renderer>().material.color = oldColor;
    }
    public void Redo()
    {
        Do(); 
    }
}