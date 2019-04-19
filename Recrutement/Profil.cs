using System.Collections.Generic;

namespace ddd
{
    public class Profil
    {
        public uint Experience { get; }
        public List<string> Competences { get; }
        
        public Profil(List<string> competences, uint experience)
        {
            Competences = competences;
            Experience = experience;
        }
    }
}