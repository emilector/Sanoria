using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanoria
{
    public class Data
    {
        public Dictionary<int, attributes> map = new Dictionary<int, attributes>();

        public void newStruct(int id, string name, string value, string comment, string date)
        {
            attributes attribute = new attributes(id, name, value, comment, date);
            map.Add(id, attribute);
        }

        public struct attributes
        {
            public string name, value, date, comment;
            int id;

            public attributes(int p_id, string p_name, string p_value, string p_comment, string p_date)
            {
                id = p_id;
                name = p_name;          
                value = p_value;
                date = p_date;
                comment = p_comment;
            }
        }

        internal int getKeybyName(string name)
        {
            foreach (var element in map)
            {
                if (element.Value.name == name)
                    return element.Key;
            }
                return -1;
        }

        internal bool changeAttribute(string p_oldName, string p_name, string p_value, string p_comment)
        {
            if (!checkifExistant(p_oldName, p_name))
            {
                Data.attributes tile = map[getKeybyName(p_oldName)];
                tile.name = p_name;
                tile.value = p_value;
                tile.comment = p_comment;
                map[getKeybyName(p_oldName)] = tile;

                return true;
            }

            else
                return false;
        }

        internal void deleteAttribute(string p_name)
        {
            map.Remove(getKeybyName(p_name));
        }

        internal bool checkifExistant(string p_oldName, string p_name)
        {
            if (p_oldName == p_name)
                return false;

            for(int i = 0; i < map.Count; i++)
            {
                if (map[i].name == p_name)
                    return true;
            }

            return false;
        }

        internal void resetData()
        {
            int amount = map.Last().Key;

            for (int i = 0; i <= amount; i++)
            {
                map.Remove(i);
            }
        }
    }
}
