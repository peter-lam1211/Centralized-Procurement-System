using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.RepresentationModel;

namespace Purchase_Request
{
    public static class Permission
    {
        public static Dictionary<string, List<string>> permissions = new Dictionary<string, List<string>>();

        public static Dictionary<string, List<string>> excepts = new Dictionary<string, List<string>>();

        public static User user = null;

        public static void LoadPermission()
        {
            var input = new MemoryStream(global::Purchase_Request.Properties.Resources.permission);

            var yaml = new YamlStream();

            yaml.Load(new StreamReader(input));

            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

            foreach (var child in mapping.Children) {
                var key = (YamlScalarNode)child.Key;
                string name = key.Value;
                //MessageBox.Show(key.Value);
                var body = (YamlMappingNode)child.Value;
                try
                {
                    var permissionNodes = (YamlSequenceNode)body.Children[new YamlScalarNode("permission")];
                    List<string> permissionList = new List<string>();
                    foreach (var permission in permissionNodes.Children)
                    {
                        permissionList.Add(permission.ToString());
                    }
                    permissions.Add(name, permissionList);
                }
                catch(KeyNotFoundException ex) { }
                try
                {
                    var exceptNodes = (YamlSequenceNode)body.Children[new YamlScalarNode("except")];
                    List<string> exceptList = new List<string>();
                    foreach (var except in exceptNodes.Children)
                    {
                        exceptList.Add(except.ToString());
                    }
                    excepts.Add(name, exceptList);
                }
                catch (KeyNotFoundException ex) { }
            }
            Console.WriteLine("Permission loaded");
        }

        public static bool isMatch(string user_permission, string target_permission)
        {
            string[] user_permission_nodes = user_permission.Split('.');
            string[] target_permission_nodes = target_permission.Split('.');
            if (user_permission_nodes.Length > target_permission_nodes.Length)
                return false;
            int index = 0;
            while(index < target_permission_nodes.Length)
            {
                if (user_permission_nodes[index] == "*")
                    return true;
                if (user_permission_nodes[index] != target_permission_nodes[index])
                    return false;
                index++;
                if (index == user_permission_nodes.Length && (user_permission_nodes.Length == target_permission_nodes.Length))
                    return true;
                if (index == user_permission_nodes.Length)
                    return false;
            }
            return true;
        }

        public static bool HavePermission(string permission)
        {
            if (user == null)
                return false;
            List<string> permissionList = permissions.ContainsKey(user.position) ? permissions[user.position] : permissions["User"];
            List<string> exceptList = excepts.ContainsKey(user.position) ? excepts[user.position] : null;
            if(exceptList != null)
            {
                foreach(string except in exceptList)
                {
                    //MessageBox.Show("Except: " + except);
                    if (isMatch(except, permission))
                        return false;
                }
            }
            if (permissionList != null)
            {
                foreach (string p in permissionList)
                {
                    //MessageBox.Show("Permission: " + p);
                    if (isMatch(p, permission))
                        return true;
                }
            }
            return false;
        }

        public static bool TryExecute(string permission)
        {
            if (HavePermission(permission))
                return true;
            MessageBox.Show("You don't have permission " + permission, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
