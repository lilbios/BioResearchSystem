using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.DomainModels.DeviceModule.Biology
{
    public class DnaUnit
    {
        private StringBuilder DnaChain;
        public DnaUnit(int size)
        {
            DnaChain = new StringBuilder(size);
        }

        public StringBuilder ConcatenateNucleobase(string chunckNucleobase) 
            => DnaChain.Append(chunckNucleobase);

        public int DnaLength => DnaChain.Length;

        public override string ToString() => DnaChain.ToString();


    }
}
