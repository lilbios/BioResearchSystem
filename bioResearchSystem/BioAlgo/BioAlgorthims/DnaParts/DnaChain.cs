using System;
using System.Collections.Generic;
using System.Text;

namespace BioAlgo.BioAlgorthims.DnaParts
{
    public struct DnaChain
    {
        private byte[] genome;
        public byte[] Genome { get => genome; }
        public int Length { get => genome.Length; }

        public DnaChain(byte[] convertedGenome)
        {
            genome = convertedGenome;
        }
    }
}
