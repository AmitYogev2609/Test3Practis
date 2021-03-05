using System;

using System.Text;
using DataStructure;

namespace Test3Practis
{
    class HiTec
    {
        private Stack<string>[] employes;
        public HiTec()
        {
            employes = new Stack<string>[9];
            for (int i = 0; i < employes.Length; i++)
            {
                employes[i] = new Stack<string>();
            }
        }
        public void AddEmploy(string id, int num)
        {
            employes[num - 1].Push(id);
        }
        public string RemoveEmploy( int posion)
        {
            if(!employes[posion - 1].IsEmpty())
            return employes[posion - 1].Pop();
            throw new NullReferenceException();
        }
        public string RemoveMany(int num, int pos)
        {
            string ids = "";
            for (int i = 0; i < num; i++)
            {
                try
                {
                    ids += RemoveEmploy(pos);
                }
                catch(Exception e)
                {
                    i = num;
                }
            }
            return ids;
        }
    }
    class WithClass
    {
    }
}
