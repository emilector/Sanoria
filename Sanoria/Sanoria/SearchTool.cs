using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sanoria
{
    public class SearchTool
    {
        public SearchTool(ref TextBox txtb, ref ListBox listBox, ref Data data)
        {
            listBox.Items.Clear();

            if (txtb.Text == "" || txtb.Text == null)
            {
                listBox.Items.Clear();
            }
            else
            {
                for (int i = 0; i < data.map.Count; i++)
                {
                    foreach(var element in data.map)
                    {
                        string name = element.Value.name.ToLower();

                        if (name.Contains(txtb.Text.ToLower()))
                        {
                            if (!listBox.Items.Contains(element.Value.name))
                                listBox.Items.Add(element.Value.name);
                        }
                    }
                }
            }
        }
    }
}
