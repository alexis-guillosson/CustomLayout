using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree  {
    public string value;
    public List<Tree> children;
   
    public Tree(string s)
    {
        value = s;
        children = new List<Tree>();
    }

    public List<Tree> FindPath(Tree target)
    {
        List<Tree> path = new List<Tree>();
        path.Add(this);
        if (target == this)
        {
            return path;
        }

        foreach (Tree tr in children)
        {
            List<Tree> childpath = tr.FindPath(target);
            if (childpath != null)
            {
                path.AddRange(childpath);
                return path;
            }
        }
        return null; 
    }
}
