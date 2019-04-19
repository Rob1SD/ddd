using System;
using System.Collections;
using System.Collections.Generic;

namespace ddd
{
    public class Profil
    {
        public uint Experience { get; }
        public IEnumerable<string> Competences { get; }
        
        public Profil(List<string> competences, uint experience)
        {
            Competences = competences;
            Experience = experience;
        }
    }
}