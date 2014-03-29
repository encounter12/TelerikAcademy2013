using System;
using System.Linq;

namespace DocumentSystem
{
    public interface IEncryptable
    {
        bool Isencrypted { get; }

        void Encrypt();

        void Decrypt();
    }
}