using BioAlgo.BioAlgorthims.DnaParts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioAlgo.BioAlgorthims.Algorithms.KmersComputing
{
    public class KMC
    {
        private readonly  Hashtable hashTable;
        private static object locker = new object();
        public KMC()
        {
            hashTable = Hashtable.Synchronized(new Hashtable());
        }

        public Hashtable BuildAcidDictionary(int k, string dnaChain)
        {

            Parallel.For(0, dnaChain.Length, (i, state) =>
            {
                if (dnaChain.Length - i < k)
                {
                    state.Break();
                }
                var subKmer = string.Join("", dnaChain.Skip(i).Take(k));

                lock (locker)
                {
                    if (hashTable.ContainsKey(subKmer))
                    {
                        hashTable[subKmer] = ((int)hashTable[subKmer]) + 1;
                    }
                    else
                    {
                        hashTable.Add(subKmer, 1);
                    }
                }
            });
            return hashTable;
        }

    }
}
