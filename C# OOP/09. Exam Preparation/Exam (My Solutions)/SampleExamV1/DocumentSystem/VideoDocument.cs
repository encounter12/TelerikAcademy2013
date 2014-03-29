using System;
using System.Linq;

namespace DocumentSystem
{
    class VideoDocument : MultimediaDocument
    {
        private string framerate;

        public VideoDocument(string name) : base(name)
        { 
        }
       
        public string Framerate
        {
            get
            {
                return this.framerate;
            }
            set
            {
                this.framerate = value;
            }
        }
    }
}