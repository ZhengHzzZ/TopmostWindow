using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMost
{
    public class FormInfo
    {
        public FormInfo(string title, int handle)
        {
            this.title = title;
            this.handle = handle;
        }
        private string title;
        private int handle;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        public override string ToString()
        {
            return this.title;
        }
    }
}
