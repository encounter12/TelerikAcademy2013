using System;
using System.Linq;

namespace DocumentSystem
{
    class AudioDocument : MultimediaDocument
    {
        private string samplerate;

        public AudioDocument(string name) : base(name)
        { 
        }
       
        public string Samplerate
        {
            get
            {
                return this.samplerate;
            }
            set
            {
                this.samplerate = value;
            }
        }
    }
}