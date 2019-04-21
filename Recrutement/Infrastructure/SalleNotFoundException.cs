using System;

namespace Recrutement.Infrastructure
{
    public class SalleNotFoundException : Exception
    {
        public SalleNotFoundException(string message) : base(message) { }
    }
}