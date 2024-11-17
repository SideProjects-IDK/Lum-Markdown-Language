using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using static lum.Program;
using static lum.utils.log;

namespace lum.utils
{
    public class files
    {
        public class createEnv
        {
            public class __list__
            {
                public static List<string> Dirs = new List<string>
                {
                    Path.Join($"C:\\Users\\{Environment.UserName}", ".lum-transpiler"),
                };

                public static List<string> Filepaths = new List<string>
                {
                    Path.Join($"C:\\Users\\{Environment.UserName}", ".lum-transpiler\\lum.config.json"),
                };

            }
            public static bool EnvFiles()
            {
                if (!IsUpdatingAllowed)
                    return false;

                info($"Creating envoirnment files in `C:\\Users\\{Environment.UserName}`");

                foreach (var _d in __list__.Dirs)
                {
                    if (!Directory.Exists(_d))
                    {
                        out_custom(" Directory", ConsoleColor.DarkGreen, _d);
                        Directory.CreateDirectory(_d);
                    }
                    else
                    {
                        out_custom(" Directory Already Exists", ConsoleColor.DarkGreen, _d);
                    }
                }

                foreach (var _f in __list__.Filepaths)
                {
                    if (!File.Exists(_f))
                    {
                        out_custom(" Json-File", ConsoleColor.Green, _f);
                        var ConfigFileJsonCode = new lumConfig
                        {
                            Version = __Version__
                        };
                        File.WriteAllText(_f, JsonSerializer.Serialize(ConfigFileJsonCode, new JsonSerializerOptions { WriteIndented = true }));
                    }
                    else
                    {
                        out_custom(" File Already Exists", ConsoleColor.DarkGreen, _f);
                        Console.WriteLine(File.ReadAllText(_f));
                    }
                }

                return true;
            }

            public class lumConfig
            {
                public string Version { get; set; }

                public bool VinCompatable { get; set; } = true;
                public bool NuCompatable { get; set; } = true;
                public Vin VinSettings { get; set; } = new Vin();

                public class Vin
                {
                    public string AdminUser { get; set; } = "root";
                }
            }
        }
        public class createProject
        {
            public static bool New(string projectname)
            {
                info($"Creating new project in `{Environment.CurrentDirectory}`");


                #region Project Dir Create
                {
                    string ProjectNamw = Path.Join(Environment.CurrentDirectory, projectname);
                    if (Directory.Exists(ProjectNamw))
                    {
                        out_custom(" Directory Already Exists", ConsoleColor.DarkGreen, ProjectNamw);
                        return false;
                    }
                    else
                    {
                        out_custom($" {projectname}-Directory", ConsoleColor.DarkGreen, ProjectNamw);
                        Directory.CreateDirectory(ProjectNamw);    
                    }
                }
                #endregion

                #region Project Config File Create
                {
                    string ProjectConfigFile = Path.Join(Environment.CurrentDirectory, projectname);
                    if (File.Exists(ProjectConfigFile))
                    {
                        out_custom(" File Already Exists", ConsoleColor.DarkGreen, ProjectConfigFile);
                        return false;
                    }
                    else
                    {
                        out_custom(" Config.Json-File", ConsoleColor.DarkGreen, ProjectConfigFile);
                        var config_project_code = new lumNewProject
                        {
                            Name = projectname
                        };
                        File.WriteAllText(ProjectConfigFile, JsonSerializer.Serialize(config_project_code, new JsonSerializerOptions { WriteIndented = true }));
                    }
                }
                #endregion

                #region Project Dir/Src Create
                {
                    string ProjectNamw = Path.Join(Environment.CurrentDirectory, projectname);
                    string SrcDirectory = Path.Join(ProjectNamw,"src");

                    if (Directory.Exists(SrcDirectory))
                    {
                        out_custom(" Directory Already Exists", ConsoleColor.DarkGreen, SrcDirectory);
                        return false;
                    }
                    else
                    {
                        out_custom($" Src-Directory", ConsoleColor.DarkGreen, SrcDirectory);
                        Directory.CreateDirectory(SrcDirectory);
                    }
                }
                #endregion

                #region Project Dir/Src Create
                {
                    string ProjectNamw = Path.Join(Environment.CurrentDirectory, projectname);
                    string SrcDirectory = Path.Join(ProjectNamw, "src");
                    string BasicCodeFile = Path.Join(SrcDirectory, "file1.lum");

                    if (File.Exists(BasicCodeFile))
                    {
                        out_custom(" File Already Exists", ConsoleColor.DarkGreen, BasicCodeFile);
                        return false;
                    }
                    else
                    {
                        out_custom(" File1.Lum-File", ConsoleColor.Green, BasicCodeFile);
                        File.WriteAllText(BasicCodeFile, "# This is a header\r\nThis is a regular paragraph.\r\n*This is a bold text.*\r\n_This is an italic text._");
                    }
                }
                #endregion

                return true;
            }

            public class lumNewProject
            {
                public string Name { get; set;}
                public string Version { get; set; } = __Version__;
                public string HomeDir { get; set; } = Environment.CurrentDirectory;
                public Owner Author { get; set; } = new Owner();
                public class Owner
                {
                    public string Username { get; set; } = Environment.UserName;
                    public string Domainname { get; set; } = Environment.UserDomainName;
                }
            }
        }
    }
}
