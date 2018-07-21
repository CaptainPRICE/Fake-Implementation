using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

static class Program
{
    static int Main(string[] args)
    {
        if ((args == null) || (args.Length == 0))
        {
            return 1;
        }
        try
        {
            foreach (FileInfo fileInfo in GetFiles())
            {
                using (FileStream fileStream = fileInfo.OpenRead())
                {
                    AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(fileStream);
                    ModuleDefinition module = assembly.MainModule;
                    foreach (MethodBody body in module.GetTypes().Where(type => type.HasMethods).SelectMany(type => (from method in type.Methods where method.HasBody select method.Body)))
                    {
                        body.ExceptionHandlers.Clear();
                        body.Variables.Clear();
                        body.Instructions.Clear();
                    }
                    {
                        FileInfo outputFileInfo = new FileInfo(Path.Combine(fileInfo.DirectoryName ?? String.Empty, Path.GetFileNameWithoutExtension(fileInfo.Name) + "-preview" + fileInfo.Extension));
                        if (outputFileInfo.Exists)
                        {
                            outputFileInfo.Delete();
                        }
                        using (FileStream outputFileStream = outputFileInfo.OpenWrite())
                        {
                            assembly.Write(outputFileStream);
                        }
                        if (File.Exists(Path.ChangeExtension(fileInfo.FullName, "xml")))
                        {
                            File.Copy(Path.ChangeExtension(fileInfo.FullName, "xml"), Path.ChangeExtension(outputFileInfo.FullName, "xml"), true);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            Console.Error.WriteLine(ex.StackTrace);
            return 2;
        }
        return 0;

        IEnumerable<FileInfo> GetFiles()
        {
            foreach (FileInfo fileInfo in args.Select(fileName => new FileInfo(fileName)).Where(fileInfo => fileInfo.Exists))
            {
                yield return fileInfo;
            }
        }
    }
}