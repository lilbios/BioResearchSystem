using BioAlgo.BioAlgorthims.DnaParts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioAlgo.BioAlgorthims.Algorithms.KmersComputing
{
    public class KMC
    {
        private readonly  Hashtable hashTable;
        public KMC()
        {
            hashTable = new Hashtable();
        }

        public Hashtable CalculateFrequencyKmer(int k, DnaChain dnaChain ) {

            for (int i = 0; i <dnaChain.Length; i++)
            {
                var subKmer = dnaChain.Genome.Skip(i).Take(k).ToArray();

                if (hashTable.ContainsKey(subKmer))
                {
                    hashTable[subKmer] = ((int)hashTable[subKmer]) + 1;
                }
                else {
                    hashTable.Add(subKmer,1);
                }
            }
            return hashTable;
        }

    }
}
