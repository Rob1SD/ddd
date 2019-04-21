using System;

namespace Recrutement.Infrastructure
{
    public class RecruteurNotFoundException : Exception
    {
        public RecruteurNotFoundException(string message) : base(message) { }
    }
}