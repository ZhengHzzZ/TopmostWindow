using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopMost
{
    public class FormInfo
    {
        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="title"></param>
        /// <param name="handle"></param>
        public FormInfo(string title, int handle)
        {
            this.title = title;
            this.handle = handle;
        }

        private string title;//window's title
        private int handle;//handle of window

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

        /// <summary>
        /// Override for showing in the listbox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.title;
        }
    }
}
