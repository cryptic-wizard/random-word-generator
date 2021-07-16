using Gtk;
using System;
using System.Collections.Generic;
using System.Text;
using UI = Gtk.Builder.ObjectAttribute;

namespace NameGeneratorGUI
{
    class ComboBox : Gtk.ComboBox
    {
        public string Text { get; private set; }

        public ComboBox(List<string> text) : base(text.ToArray())
        {
            Changed += ComboBox_Changed;
        }

        // https://stackoverflow.com/questions/14858893/gtk-sharp-refresh-redraw-widget/14873882#14873882
        public void SetOptions(List<string> text)
        {
            Clear();

            ListStore listStore = new ListStore(typeof(string));

            foreach (string line in text)
            {
                listStore.AppendValues(line);
            }

            Model = listStore;
            CellRendererText textRender = new CellRendererText();
            PackStart(textRender, true);
            AddAttribute(textRender, "text", 0);
            Active = 0;
        }

        // Update text on changed event
        private void ComboBox_Changed(object sender, EventArgs e)
        {
            TreeIter treeIter;
            GetActiveIter(out treeIter);
            Text = (String)Model.GetValue(treeIter, 0);
        }
    }
}
