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
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts 2D_INTEGER_ARRAY gb as parameter.
     */
    
    public static int find(int x, List<List<int>> parent){
            if(x==parent[x][0]){
                return x;
            }
            parent[x][0]=find(parent[x][0], parent);
            return(parent[x][0]);
        }
    
    public static List<List<int>> union(int x, int y, List<List<int>> parent){
        if (parent[x][1]>=parent[y][1]){
            parent[x][1]+=parent[y][1];
            parent[y][0]=x;   
            parent[y][1]=1;
        }
        else{
            parent[y][1]+=parent[x][1];
            parent[x][0]=y;
            parent[x][1]=1;
            }
        return parent;
            }
        
    
    public static List<int> componentsInGraph(List<List<int>> gb)
    {
        List<int> x = new List<int>();
        List<List<int>> parent = new List<List<int>>();
        int N=1;
        
        foreach(var edge in gb){
         if(N<edge[1]){
             N = edge[1];
         }
        }
        parent = (from i in Enumerable.Range(0, 2 * N + 1)
        select new List<int> {i,1}).ToList();

        foreach(var edge in gb){
            var px=find(edge[0],parent);
            var py=find(edge[1],parent);
            if(px!=py){
            parent = union(px,py, parent);
            }
        }
        
        
    List<int> lists = new List<int>();
    int n = 2*N+1;
    for(int i=0;i<n;i++){
        if(parent[i][1]>1){
            lists.Add(parent[i][1]);
        }   
    }
    
    lists.Sort();

    x.Add(lists[0]);
    x.Add(lists[lists.Count-1]);
    return x;     
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


