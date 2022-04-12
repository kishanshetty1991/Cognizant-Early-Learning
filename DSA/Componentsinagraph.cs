using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'componentsInGraph' function below.
     *
     * The function is expected to return an int_ARRAY.
     * The function accepts 2D_int_ARRAY gb as parameter.
     */

    public static List<int> componentsInGraph(List<List<int>> comp)
    {
        List<int> li = new List<int>();
        li.Add(int.MinValue);
        li.Add(int.MaxValue);
       
        Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
        foreach(List<int> q in comp)
        {
            HashSet<int> set0 = map.ElementAtOrDefault(q[0],new HashSet<int>());
            set0.add(q.get(1));
            map.put(q.get(0),set0);
            Set<int> set1 = map.getOrDefault(q.get(1),new HashSet<>());
            set1.add(q.get(0));
            map.put(q.get(1),set1);
        }
        while(map.size()>0)
        {
            Set<int> dis = new HashSet<>();
            LinkedList<int> bfs = new LinkedList<>();
            Map.Entry<int,Set<int>> ent = map.entrySet().iterator().next();
            map.remove(ent.getKey());
            dis.add(ent.getKey());
            bfs.addAll(ent.getValue());
            while(bfs.size()>0)
            {
                int pop=bfs.removeFirst();
                if(map.containsKey(pop))
                {
                    dis.add(pop);
                    bfs.addAll(map.get(pop));
                    map.remove(pop);
                }
            }
            li.set(0,int.min(li.get(0),dis.size()));
            li.set(1,int.max(li.get(1),dis.size()));
        }
        return li;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> gb = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            gb.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(gbTemp => Convert.ToInt32(gbTemp)).ToList());
        }

        List<int> result = Result.componentsInGraph(gb);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}

